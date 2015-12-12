using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace MALDI_HTML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openfile = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openfile.ShowDialog();

            if (result == true)
            {
                string filename = openfile.FileName;
                fileinbox.Text = filename;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            datalist.Items.Add(fileinbox.Text);
        }

        private void createhtml_Click(object sender, RoutedEventArgs e)
        {
            string htmltoinsert = "";

            List<string> filelist = datalist.Items.OfType<string>().ToList();
            foreach (string spectrafile in filelist)
            {
                List<string> filedata = File.ReadLines(spectrafile).ToList();
                testbox.ItemsSource = filedata;


            }


        }
    }
}
