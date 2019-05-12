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
using System.Xml;
using System.Xml.Serialization;
using WPFApp.Helpers;


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
            pathOfXmlFile.Text = Helpers.XmlSelector.getSelectedXmlPath();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            var xmlData = XmlProcessor.LoadXml(pathOfXmlFile.Text);

            MessageBox.Show(xmlData.Customer);
            //XmlSerializer serializer = new XmlSerializer(typeof(WebOrder));

            //using (FileStream fileStream = new FileStream(@""+ pathOfXmlFile.Text, FileMode.Open))
            //{
            //    WebOrder result = (WebOrder)serializer.Deserialize(fileStream);
            //    foreach (var item in result.Items)
            //    {
            //        foreach (var item2 in item.Item)
            //        {
            //            MessageBox.Show(item2.Quantity);
            //        }
            //    }
            //}
        }
        public static void displayValues(string id, string customer, string date, string priceAverage, string total)
        {

        }
    }
   
}
