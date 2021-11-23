using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutronicFingerPrint
{
    static class Program
    {
        private static IServiceProvider serviceProvider { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var services = new ServiceCollection();
            //ConfigureServices();

            Application.Run(new MainForm());
        }

        public static IServiceContainer ConfigureServices()
        {
            IServiceContainer services = new ServiceContainer();
            services.AddService(typeof(MainForm), new MainForm());

            
            return services;
        }
    }
}
