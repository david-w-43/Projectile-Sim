using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectile_Sim
{
    //static class Program
    //{
    //    /// <summary>
    //    /// The main entry point for the application.
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new Form1());
    //    }
    //}

    static class Program
    {
        public static Form1 form1; // = new Form1(); // Place this var out of the constructor


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form1 = new Form1());

            //Handles uncaught exceptions, usually object in use
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
        }


        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            //Writes error to console
            Console.WriteLine(e.ExceptionObject.ToString());
        }
    }


}
