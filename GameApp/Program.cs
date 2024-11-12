using GameApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT601_Game
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool testMode = true; // false: run program: true run tests
            bool csharpTests = true; // false: run standard MySQL tests, true test for C# error handling
            if (testMode)
            {
                // Run database tests
                if (csharpTests)
                {
                    TesterErrors.Test(); // test C# error handling
                }
                else
                {
                    Tester.Test(); // Test procedures and methods work
                }
            }
            else
            {
                // Run form version
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(GameManager.LoadLogin());
            }
        }
    }
}
