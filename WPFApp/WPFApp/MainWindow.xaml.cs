using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPFApp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog _fileDialogObj = new OpenFileDialog();
            _fileDialogObj.Title = "Open XML File";
            _fileDialogObj.Filter = "XML files|*.xml";
            _fileDialogObj.InitialDirectory = @"C:\";
            Nullable<bool> resultOfDialog = _fileDialogObj.ShowDialog();
            if (resultOfDialog == true)
            {
                try
                {
                    pathOfXmlFile.Text = _fileDialogObj.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
