using System;
using System.Windows.Forms;
using Mod10_02.Forms;

namespace Mod10_02
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ContactManagerForm());
        }
    }
}
