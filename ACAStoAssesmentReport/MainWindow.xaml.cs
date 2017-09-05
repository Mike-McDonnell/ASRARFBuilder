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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectScanButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            if(dlg.ShowDialog() == true)
            {
                ASRARFBuilder.Converter converter = new ASRARFBuilder.Converter();

                var arequest = new ARequest();

                arequest.SecurityCenterAddress = "Generic.SecuritySystem.com";
                arequest.DataPublisherVersion = "1.0";
                arequest.DataPublisher = "Assesment Report Publisher";
                arequest.ASRReportType = "acas.plugin.results";

                using (var filestream = dlg.OpenFile())
                {
                    using (var streamReader = new System.IO.StreamReader(filestream, Encoding.UTF8))
                    {
                        arequest.ACASXML = streamReader.ReadToEnd();
                    }
                }

                var test = converter.ProcessAssesmentRequest(arequest);

                var test2 = test.ARFXML;
            }
        }
    }
}
