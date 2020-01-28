using System;
using System.Windows.Forms;

namespace Projectile_Sim
{
    static class Program
    {
        public static UIForm form1; // = new Form1(); // Place this var out of the constructor


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form1 = new UIForm());

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
