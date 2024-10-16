using GameApp;
using System;
using System.Collections.Generic;
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
            bool testMode = false;
            if (testMode)
            {
                // Run database tests
                Tester.Test();
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
