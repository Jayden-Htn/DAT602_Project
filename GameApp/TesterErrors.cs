using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using K4os.Compression.LZ4.Internal;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Xml.Linq;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using System.Transactions;

namespace GameApp
{
    internal class TesterErrors
    {
        /// <summary>
        /// Run tests on all database procedures to check C# error handling.
        /// </summary>
        static public void Test() {
            daoUser.Login("Player1", "Password123"); // Establish connection first for cleaner output
            
            Debug.WriteLine("\n\n\n\n<======== STARTING DATABASE TESTING ========>");

            // Login procedure
            Debug.WriteLine("\n<==== 1. Login procedure tests ====>");
            Debug.WriteLine(daoUser.Login("Player1", "Password123")); // Successful login
            Debug.WriteLine(daoUser.Login("'; drop table tblPlayer; --", "password123")); // Throws error


            // Register procedure
            Debug.WriteLine("\n<==== 2. Register procedure tests ====>");
            Debug.WriteLine(daoUser.Register("Player5", "Password123")); // Successful register
            Debug.WriteLine(daoUser.Register("'; drop table tblPlayer; --", "password123")); // Throws error


            // Layout procedure
            Debug.WriteLine("\n<==== 3. Layout procedure tests ====>");

            List<objTile> tileList = daoGame.GetMap(1, 1);
            Debug.WriteLine("Tiles:");
            foreach (objTile tile in tileList)
            {
                Debug.WriteLine($" - {tile.ToString()}");
            } 
            tileList.Clear(); // Successful output
            // Note: I am unable to purposefully cause an error to demonstrate the c# error trapping 


            // Generate map procedure
            Debug.WriteLine("\n<==== 4. Generate map procedure tests ====>");
            tileList = daoGame.GenerateMap(2);
            int count = 1;
            Console.WriteLine("Tiles:");
            foreach (objTile tile in tileList)
            {
                Debug.WriteLine($" - #{count} {tile.ToString()}");
                count++;
            } // Success

            tileList = daoGame.GenerateMap(-1);
            count = 1;
            Console.WriteLine("Tiles:");
            foreach (objTile tile in tileList)
            {
                 Debug.WriteLine($" - #{count} {tile.ToString()}");
                 count++;
            } // Throws error from invalid game ID

            
            // Move player procedure
            Debug.WriteLine("\n<==== 5. Move player procedure tests ====>");
            Debug.WriteLine(daoGame.MovePlayer(1, 1, 0, 0)); // Success
            // Note: I am unable to purposefully cause an error to demonstrate the c# error trapping 


            // Update score procedure
            Debug.WriteLine("\n<==== 6. Update score procedure tests ====>");
            Debug.WriteLine(daoGame.UpdateScore(1, 20)); // Success
            // Note: I am unable to purposefully cause an error to demonstrate the c# error trapping 


            // Interact procedure
            Debug.WriteLine("\n<==== 7. Tile interact procedure tests ====>");
            Debug.WriteLine(daoGame.TileInteract(1, 1, 2, 1)); // Success
            // Note: I am unable to purposefully cause an error to demonstrate the c# error trapping 


            // NPC Move procedure
            Debug.WriteLine("\n<==== 8. NPC move procedure tests ====>");
            Debug.WriteLine(daoGame.NpcMove(1)); // Success
            // Note: I am unable to purposefully cause an error to demonstrate the c# error trapping 

            
            // Stop game procedure
            Debug.WriteLine("\n<==== 9. Stop game procedure tests ====>");
            Debug.WriteLine(daoGame.StopGame(1)); // Success
            // Note: I am unable to purposefully cause an error to demonstrate the c# error trapping 

            
            // Update player procedure
            Debug.WriteLine("\n<==== 10. New player procedure tests ====>");
            // Please refer to register player procedure and test

            
            // Update player procedure
            Debug.WriteLine("\n<==== 11. Update player procedure tests ====>");

            DataRow user = daoUser.UpdatePlayer(1, "EpicGamer", "NewPassword", 1, 1, 0);
            if (user.Table.Columns.Contains("Message"))
            {
                Debug.WriteLine(user["Message"]);
            } else
            {
                Debug.WriteLine($"{user["ID"]} {user["Username"]} {user["Password"]} {user["LoginAttempts"]} " +
                $"{user["Locked"]} {user["Online"]} {user["Admin"]} {user["HighestScore"]}"); // Success
            }
            
            user = daoUser.UpdatePlayer(-1, "EpicGamer", "NewPassword", 1, 1, 0);
            if (user.Table.Columns.Contains("Message"))
            {
                Debug.WriteLine(user["Message"]); // Error thrown
            }
            else
            {
                Debug.WriteLine($"{user["ID"]} {user["Username"]} {user["Password"]} {user["LoginAttempts"]} " +
                $"{user["Locked"]} {user["Online"]} {user["Admin"]} {user["HighestScore"]}");
            }

            
            // Delete player procedure
            Debug.WriteLine("\n<==== 12. Delete player procedure tests ====>");
            Debug.WriteLine(daoUser.DeletePlayer(3)); // Success
            // Note: I am unable to purposefully cause an error to demonstrate the c# error trapping 


            Debug.WriteLine("\n\n<======== DATABASE TESTING COMPLETE ========>");
            Debug.WriteLine("Please compare test outputs to the expected results in the test class.\n");
            
        }
    }
}
