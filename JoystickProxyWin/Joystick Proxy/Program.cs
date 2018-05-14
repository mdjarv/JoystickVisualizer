using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joystick_Proxy
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
            Application.Run(new Form1());
            /*
            AppDomain currentDomain = default(AppDomain);
            currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            System.Windows.Forms.Application.ThreadException += GlobalThreadExceptionHandler;
            */
        }

        /*
        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = (Exception)e.ExceptionObject;
            //ILog log = LogManager.GetLogger(typeof(Program));
            //log.Error(ex.Message + "\n" + ex.StackTrace);
        }

        private static void GlobalThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = e.Exception;
            //ILog log = LogManager.GetLogger(typeof(Program)); //Log4NET
            //log.Error(ex.Message + "\n" + ex.StackTrace);
        }
        */
    }
}
