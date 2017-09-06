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

namespace ACAStoAssesmentReport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ARequest arequest;
        private string ACASFileName;

        public MainWindow()
        {
            InitializeComponent();

            arequest = new ARequest();

            ScanDataGrid.ItemsSource = new List<ARequest>() { arequest };
        }

        private void SelectScanButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "*.nessus";
            dlg.Filter = "ACAS scan file (*.nessus)|*.nessus";

            if (dlg.ShowDialog() == true)
            {
                using (var filestream = dlg.OpenFile())
                {
                    using (var streamReader = new System.IO.StreamReader(filestream, Encoding.UTF8))
                    {
                        arequest.ACASXML = streamReader.ReadToEnd();
                    }
                }

                ACASFileName = dlg.FileName;
                SaveButton.IsEnabled = true;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = ACASFileName.Replace(".nessus", "");

            if (dlg.ShowDialog() == true)
            {
                ASRARFBuilder.Converter converter = new ASRARFBuilder.Converter();
                var response = converter.ProcessAssesmentRequest(arequest);

                using (System.IO.StreamWriter filestream = new System.IO.StreamWriter(dlg.FileName + ".ARF.xml", false, Encoding.UTF8))
                {
                    filestream.WriteLine(response.ARFXML);
                }

                using (System.IO.StreamWriter filestream = new System.IO.StreamWriter(dlg.FileName + ".ASR.xml", false, Encoding.UTF8))
                {
                    filestream.WriteLine(response.ASRXML);
                }
            }
        }
    }
}
