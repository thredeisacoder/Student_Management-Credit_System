using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV_HTC.GUI;

namespace QLDSV_HTC
{
    static class Program
    {
        // User information
        public static string Username = "";
        public static string Role = "";
        public static string FullName = "";
        public static string MaKhoa = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
