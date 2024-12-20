﻿using Google.Protobuf.Collections;
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

namespace GameApp
{
    internal class Tester
    {
        /// <summary>
        /// Run tests on all database procedures.
        /// </summary>
        static public void Test() {
            daoUser.Login("Player1", "Password123"); // Establish connection first for cleaner output
            
            Debug.WriteLine("\n\n\n\n<======== STARTING DATABASE TESTING ========>");

            // Login procedure
            Debug.WriteLine("\n<==== 1. Login procedure tests ====>");
            Debug.WriteLine(daoUser.Login("Player1", "Password123")); // Output: <Player ID>
            Debug.WriteLine(daoUser.Login("Player1", "Password")); // Output: 'Invalid credentials'
            Debug.WriteLine(daoUser.Login("Player46", "Password123")); // Output: 'No account'
            Debug.WriteLine(daoUser.Login("Player4", "Password123")); // Output: 'Locked out'

            // Register procedure
            Debug.WriteLine("\n<==== 2. Register procedure tests ====>");
            Debug.WriteLine(daoUser.Register("Player5", "Password123")); // Output: <Player ID>
            Debug.WriteLine(daoUser.Register("Player5", "Password123")); // Output: 'Duplicate'

            // Layout procedure
            Debug.WriteLine("\n<==== 3. Layout procedure tests ====>");
            List<objTile> tileList = daoGame.GetMap(1, 1);
            Console.WriteLine("Tiles:");
            foreach (objTile tile in tileList)
            {
                Debug.WriteLine($" - {tile.ToString()}");
            } // Output: three unique tiles within 4 tiles of character
            tileList.Clear();

            // Generate map procedure
            Debug.WriteLine("\n<==== 4. Generate map procedure tests ====>");
            tileList = daoGame.GenerateMap(2);
            int count = 1;
            Console.WriteLine("Tiles:");
            foreach (objTile tile in tileList)
            {
                Debug.WriteLine($" - #{count} {tile.ToString()}");
                count++;
            } // Approximately 33 unique tiles


            // Move player procedure
            Debug.WriteLine("\n<==== 5. Move player procedure tests ====>");
            Debug.WriteLine(daoGame.MovePlayer(1, 1, 0, 0)); // Output: 'Out of map'
            Debug.WriteLine(daoGame.MovePlayer(1, 1, 5, 5)); // Output: 'Tile not in range'
            Debug.WriteLine(daoGame.MovePlayer(1, 1, 1, 1)); // Output: 'Character already in position'
            Debug.WriteLine(daoGame.MovePlayer(1, 1, 2, 2)); // Output: 'Successful move'

            // Update score procedure
            Debug.WriteLine("\n<==== 6. Update score procedure tests ====>");
            Debug.WriteLine(daoGame.UpdateScore(1, 20)); // Output: 'Score updated'
            Debug.WriteLine(daoGame.UpdateScore(456, 20)); // Output: 'Player not found'

            // Interact procedure
            Debug.WriteLine("\n<==== 7. Tile interact procedure tests ====>");
            Debug.WriteLine(daoGame.TileInteract(1, 1, 2, 1)); // Output: 'Success' (collect)
            Debug.WriteLine(daoGame.TileInteract(1, 1, 2, 2)); // Output: 'Success' (fight)
            Debug.WriteLine(daoGame.TileInteract(1, 1, 2, 2)); // Output: 'Tile not found'
            Debug.WriteLine(daoGame.TileInteract(1, 1, 3, 2)); // Output: 'Success' (pickup)

            // NPC Move procedure
            Debug.WriteLine("\n<==== 8. NPC move procedure tests ====>");
            Debug.WriteLine(daoGame.NpcMove(1)); // Output: between 0 - 2 (random)
            Debug.WriteLine(daoGame.NpcMove(1)); // Output: between 0 - 2
            Debug.WriteLine(daoGame.NpcMove(1)); // Output: between 0 - 2

            // Stop game procedure
            Debug.WriteLine("\n<==== 9. Stop game procedure tests ====>");
            Debug.WriteLine(daoGame.StopGame(1)); // Output: 'Stopped game'
            Debug.WriteLine(daoGame.StopGame(null)); // Output: 'Stopped all games'

            // Update player procedure
            Debug.WriteLine("\n<==== 10. New player procedure tests ====>");
            // Please refer to register player procedure and test

            // Update player procedure
            Debug.WriteLine("\n<==== 11. Update player procedure tests ====>");
            Debug.WriteLine(daoUser.UpdatePlayer(1, "EpicGamer", "NewPassword", 1, 1, 0)); // Output: 'Player data changed'
            Debug.WriteLine(daoUser.UpdatePlayer(1, null, null, 0, 0, null)); // Output: 'Player data changed'

            // Delete player procedure
            Debug.WriteLine("\n<==== 12. Delete player procedure tests ====>");
            Debug.WriteLine(daoUser.DeletePlayer(3)); // Output: 'Success'
            Debug.WriteLine(daoUser.DeletePlayer(3)); // Output: 'Player doesn't exist'

            Debug.WriteLine("\n\n<======== DATABASE TESTING COMPLETE ========>");
            Debug.WriteLine("Please compare test outputs to the expected results in the test class.\n");
        }
    }
}
