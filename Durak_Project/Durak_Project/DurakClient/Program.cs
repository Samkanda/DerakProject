///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            Program
///   Description:      Auto generated entry point for application (Visual Studio)
///   Authors:          Shoaib Ali, Luke Richards, Navpreet Kanda, Mubashir Malik
///   Card Img Source:  http://acbl.mybigcommerce.com/52-playing-cards/  
///   Date:             April 14, 2021
///---------------------------------------------------------------------------------
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GamingForm());
            Application.Run(new Launcher());
        }
    }
}
