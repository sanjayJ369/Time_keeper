using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Time_Tracker
{
    public class data
    {
        public Dictionary<string, double> CsvData = new Dictionary<string, double>();

        string prev_program = "";
        string current_program = "";
        //location of the database(csvfile)
        public string database = "./database.csv";

        public void Create_file(string filename)
        {
            using (StreamWriter writer = File.AppendText(filename))
            {
                using var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture);
                
            }
        }

        public void modifiy_dict()
        {
            WindowAPI temp = new WindowAPI();
            string win_title = temp.ActiveWindowTitle();
            string title = temp.formatted_window(win_title);

            current_program = title;

            if (current_program ==  prev_program)
            {
                //check if the program is in the dictionary
                if (title.Trim() != "")
                {

                    if (CsvData.ContainsKey(title))
                    {
                        //0.167 = 10/60
                        CsvData[title] += 0.167;
                    }
                    else
                    {
                        //0.167 is equal to 10 seconds if a minute is 1
                        CsvData.Add(title, 0.167);
                    }
                }
            }
            
            prev_program = title;
            

        }

        //reads the data present in the csv file and return a string
        public string Read_data(string database)
        {
            using var streamReader = File.OpenText(database);

            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            string value;

            string data = "";

            while (csvReader.Read())
            {
                for (int i = 0; csvReader.TryGetField(i, out value); i += 1)
                {
                    data += value;
                }

                data += "\n";
            }

            return data;
        }

        // load data function load all the data present in the csv file into the dictonary CsvData
        // the data stored in the csv folder will be in the form of program, duriation
        public void load_data(string database="./database.csv")
        {
            using var streamReader = File.OpenText(database);
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
            string name = "";

            while (csvReader.Read())
            {
                for (int i = 0; csvReader.TryGetField(i, out name); i++)
                {   

                    string prog = name;
                    csvReader.TryGetField(++i, out name);
                    double dur;
                    double.TryParse(name, out dur);
                    CsvData.Add(prog, dur);
                }
            }
        }

        public string dispaly_data()
        {
            string i="";
            foreach (KeyValuePair<string, double> item in this.CsvData)
            {
                i += ("Key: {0}, Value: {1}", item.Key, item.Value.ToString("F5"));
                //Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value.ToString("F10"));
            }

            return i;   
        }


        public void update_csv()
        {
            //update the current csv file according to the dictonary
            using (var writer = new StreamWriter(database))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {   
                foreach(var r in this.CsvData.Keys)
                {

                    csv.WriteField(r);
                    csv.WriteField(this.CsvData[r]);
                    csv.NextRecord();

                }
            }

            Console.WriteLine("the data has been written into the csv folder");
        }
    }
}
