using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Time_Tracker;

namespace display_stats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //it take the data from the csv file and display's it to the window in the from of a graph
        public MainWindow()
        {
            InitializeComponent();
            var data_class = new Time_Tracker.data();
            data_class.load_data();
            var dic = data_class.CsvData;
            var data = data_class.dispaly_data();
            data_textblock.Text = data;
            ((ColumnSeries)Time_spent.Series[0]).ItemsSource = dic;

        }
    }
}
