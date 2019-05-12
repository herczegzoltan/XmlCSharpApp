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
        private void Call_Dialog_Button_Click(object sender, RoutedEventArgs e)
        {
            pathOfXmlFile.Text = Helpers.XmlSelector.getSelectedXmlPath();
        }
        private void Xml_Process_Button_Click(object sender, RoutedEventArgs e)
        {
            double sumTotalPrice = 0;
            double sumTotalPriceWithQuantity = 0;
            int counterItems = 0;
            double priceAverageValue    = 0;

            var xmlData = XmlProcessor.LoadXml(pathOfXmlFile.Text);

            foreach (var item in xmlData.Items)
            {
                foreach (var i in item.Item)
                {
                    sumTotalPrice = sumTotalPrice + Convert.ToDouble(i.Price.Replace(".",","));
                    sumTotalPriceWithQuantity = sumTotalPriceWithQuantity + Convert.ToDouble(i.Price.Replace(".", ",")) * Convert.ToInt16(i.Quantity);  
                    counterItems++;
                }
            }

            priceAverageValue = sumTotalPrice / counterItems;

            displayValues(xmlData.Id.ToString(),xmlData.Customer, convertDate(xmlData.Date), convertDoubleToSeparatedDouble(priceAverageValue) , convertDoubleToSeparatedDouble(sumTotalPriceWithQuantity));
        }
        public void displayValues(string id, string customer, string date, string priceAverage, string total)
        {
            idResultTextBlock.Text           = id;
            customerResultTextBlock.Text     = customer;
            dateResultTextBlock.Text         = date;
            priceAverageResultTextBlock.Text = priceAverage;
            totalResultTextBlock.Text        = total;
        }
        public string convertDate(string date)
        {
            string resultDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd.MM.yyyy");

            return resultDate;
        }
        public string convertDoubleToSeparatedDouble(double value)
        {

            CultureInfo culture = CultureInfo.CreateSpecificCulture("de-DE");
            
            return value.ToString("N3", culture);
        }
    }
}
