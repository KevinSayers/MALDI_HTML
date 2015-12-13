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

        //Gets a spectra file from openfiledialog
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

        //adds the file from the spectra input box to the list of those to be added to the html file
        private void add_Click(object sender, RoutedEventArgs e)
        {
            datalist.Items.Add(fileinbox.Text);
        }

        private void createhtml_Click(object sender, RoutedEventArgs e)
        {
            string htmltoinsert = "";

            //Reads in the HTML template file to be used to generate site
            List<string> htmltemplate = File.ReadLines(@"C:\Users\kevin\Documents\Visual Studio 2015\Projects\MALDI_HTML\graph.html").ToList() ;

            

            List<string> filelist = datalist.Items.OfType<string>().ToList();
            foreach (string spectrafile in filelist)
            {
                List<double> xvals = new List<double>();
                List<double> yvals = new List<double>();

                List<string> filedata = File.ReadLines(spectrafile).ToList();
                foreach(string line in filedata)
                {
                    double tempx;
                    double tempy;

                    tempx = System.Convert.ToDouble(line.Split(' ')[0]);
                    tempy = System.Convert.ToDouble(line.Split(' ')[1]);
                    xvals.Add(tempx);
                    yvals.Add(tempy);

                }
           
            }


        }

        private void saveas_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog savefile = new Microsoft.Win32.SaveFileDialog();
            savefile.DefaultExt = ".html";
            savefile.AddExtension = true;
            savefile.Filter = "HTML|*.html";
            Nullable<bool> result = savefile.ShowDialog();

            if (result == true)
            {
                string filename = savefile.FileName;
                outfile.Text = filename;
            }
        }
    }
}
