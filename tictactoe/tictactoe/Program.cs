using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    static class Program
    {
        // This is a standard main program when working with Forms. 
        // TTTGUI is our form where we visualise and create our GUI
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TTTGUI());
        }
    }
}
