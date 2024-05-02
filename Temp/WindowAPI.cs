using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Time_Tracker
{   
    //this class is used to get the current active window the user is on
    public class WindowAPI
    {
        public double tic1 = 1000 * 10;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hwnd, StringBuilder ss, int count);

        public string ActiveWindowTitle()
        {
            //Create the variable
            const int nChar = 256;
            StringBuilder ss = new StringBuilder(nChar);

            //Run GetForeGroundWindows and get active window informations
            //assign them into handle pointer variable
            IntPtr handle = IntPtr.Zero;
            handle = GetForegroundWindow();

            string title = "";

            

            if (GetWindowText(handle, ss, nChar) > 0) title = ss.ToString();

            return title;
            
        }

        // the function is used to get only the name of the main window
        // from the main window title
        public string formatted_window(string title)
        {
            int lastindx = title.LastIndexOf("-");

            string prog_name = "";

            if (title.Split(" ").Length == 1) return title;

            if ((lastindx) >= 0)
            {
                prog_name = title.Substring(lastindx + 1).Trim();
            }

            if (prog_name.Trim() == "")
            {
                //int l_indx = title.LastIndexOf('/');
                //string p_name;
                //if ((l_indx) >= 0)
                //{
                //    p_name = title.Substring(lastindx+1).Trim();
                //}
                //if ( p_name.Trim().Length == 0)
                //{
                //    return title;
                //}
                //return p_name;
                return title;
            }
            else
            {
                return prog_name;
            }
        }
    }
}
