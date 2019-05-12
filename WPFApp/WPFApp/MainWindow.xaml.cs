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
using System.Globalization;



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
            double sumTotalPrice = 0;
            double sumTotalPriceWithQuantity = 0;
            int counterItems = 0;

            double priceAverageValue    = 0;
            int quantityValue    = 0;

            var xmlData = XmlProcessor.LoadXml(pathOfXmlFile.Text);

            foreach (var item in xmlData.Items)
            {
                foreach (var i in item.Item)
                {
                    //tempPriceValue = Convert.ToDouble(s);
                    //MessageBox.Show("|"+i.Price.ToString()+"|");
                    sumTotalPrice = sumTotalPrice + Convert.ToDouble(i.Price.Replace(".",","));// Double.Parse(i.Price);  
                    sumTotalPriceWithQuantity = sumTotalPriceWithQuantity + Convert.ToDouble(i.Price.Replace(".", ",")) * Convert.ToInt16(i.Quantity);  
                    counterItems++;
                }
            }

            priceAverageValue = sumTotalPrice / counterItems +1000;


            CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");

            displayValues(xmlData.Id.ToString(),xmlData.Customer,xmlData.Date, priceAverageValue.ToString("N3", culture), sumTotalPriceWithQuantity.ToString("N3", culture));


        }
        public void displayValues(string id, string customer, string date, string priceAverage, string total)
        {
            idResultTextBlock.Text           = id;
            customerResultTextBlock.Text     = customer;
            dateResultTextBlock.Text         = date;
            priceAverageResultTextBlock.Text = priceAverage;
            totalResultTextBlock.Text        = total;
        }
    }
}
