// See https://aka.ms/new-console-template for more information
using CsvHelper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using Time_Tracker;

namespace Time_Tracker
{
    public class Program
    {
        // tic1 is used to update the loaded dictonaryes every tic1 milli seconds
        // tic2 is used to update the database(csvfile) based on loaded and updated dictonary
        double tic1 = 1000 * 10;
        double tic2 = 1000 * 60 * 5;

        //location of the database(name)
        string db_loc = "./database.csv";
        public data database = new data();

        public static void Main(string[] args)
        {
            Program p = new Program();
            WindowAPI winapi = new WindowAPI();

            if (File.Exists(p.db_loc))
            {
                p.database.load_data(p.db_loc);
            }
            else
            {
                p.database.Create_file(p.db_loc);
            }

            System.Timers.Timer t1 = new System.Timers.Timer();
            t1.Interval = p.tic1;
            t1.Elapsed += (sender, e) => p.update_dict(sender, e, winapi, ref p.database);

            System.Timers.Timer t2 = new System.Timers.Timer();
            t2.Interval = p.tic2;
            t2.Elapsed += (sender, e) => p.mod_datbase(sender, e, winapi, ref p.database);

            t1.Start();
            t2.Start();

            // while loop to keep the program running until it is closed
            while (true)
            {

            }

            // Wait for the user to press a key
            //Console.ReadKey();

        }

        public void update_dict(object sender, ElapsedEventArgs e, WindowAPI win, ref data database)
        {
            database.modifiy_dict();

            string title = win.ActiveWindowTitle();
            string program_title = win.formatted_window(title);
            Console.WriteLine($"this is the current program you are using : {program_title}");
        }


        // mod_database stands for modifiy database
        public void mod_datbase(object sender, ElapsedEventArgs e, WindowAPI win, ref data database)
        {
            database.update_csv();
        }
    }
}




