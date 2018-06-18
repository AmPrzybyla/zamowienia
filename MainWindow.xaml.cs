using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
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
using System.Xml.Linq;

namespace zamowienia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Order> listOfOrders = new ObservableCollection<Order>();


        public MainWindow()
        {
            InitializeComponent();
            OpenTable();
            ListOfSendedOrders.ItemsSource = listOfOrders;

        }


        private void Send()
        {
            MailMessage mail = new MailMessage("testmailcdev@gmail.com", AddressBox.Text);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            // client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("testmailcdev@gmail.com", "123edi456");
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            mail.Subject = "Zamowienie z " + DateTime.Now;
            mail.Body = "zamowienie\n";
            foreach (var item in listOfOrders[ListOfSendedOrders.SelectedIndex].listOfProducts)
            {
                mail.Body += item.NameOfProduct+ " "+ item.IndexOfProduct + " "+ item.QuantityOfProduct +"szt "+ item.PriceOfProduct+"zl/szt \n";
            }
            client.Send(mail);
        }


        private void OpenTable()
        {
            XDocument xDoc = XDocument.Load("Order.xml");

            foreach (var order in xDoc.Descendants("Order"))
            {
                string company = order.Element("Company_name").Value;
                string address = order.Element("Company_mail").Value;
                DateTime date = DateTime.Parse(order.Element("Date_mail").Value);
                bool sended = bool.Parse(order.Element("Sended_mail").Value);
                listOfOrders.Add(new Order { Company = company, Address = address, Date = date, SendedOrder=sended });
                foreach (var product in order.Descendants("Product"))
                {
                    string name = product.Element("Product_name").Value;
                    string index = product.Element("Product_index").Value;
                    int quantity = int.Parse(product.Element("Product_quantity").Value);
                    double price = double.Parse(product.Element("Product_price").Value.Replace('.', ','));
                    listOfOrders[listOfOrders.Count - 1].listOfProducts.Add(new Product { NameOfProduct = name, IndexOfProduct = index, QuantityOfProduct = quantity, PriceOfProduct = price });
                }
            }
        }

        private void DodajZamówienie_Click(object sender, RoutedEventArgs e)
        {
            listOfOrders.Add(new Order() { Company=AddressBox.Text, Date=DateTime.Now});
            ListOfSendedOrders.ItemsSource = listOfOrders;
            TableOfProducts.ItemsSource = listOfOrders[listOfOrders.Count - 1].listOfProducts;
        }



        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Save();
            Send();
            OpenTable();
        }


        private void Save()
        {

            XDocument xDoc = XDocument.Load("Order.xml");

            XElement xOrder = new XElement("Order");
            xOrder.Add();

            XElement xOrderCompany = new XElement("Company_name", CompanyBox.Text);
            XElement xOrderMail = new XElement("Company_mail", AddressBox.Text);
            XElement xOrderDate = new XElement("Date_mail", DateTime.Now);
            XElement xOrderSended = new XElement("Sended_mail", true);
            xOrder.Add(xOrderCompany);
            xOrder.Add(xOrderMail);
            xOrder.Add(xOrderDate);
            xOrder.Add(xOrderSended);
            XElement xProducts = new XElement("Products");
            foreach (var item in listOfOrders[listOfOrders.Count - 1].listOfProducts)
            {
                XElement xProduct = new XElement("Product");
                XElement xProductName = new XElement("Product_name", item.NameOfProduct);
                XElement xProductIndex = new XElement("Product_index", item.IndexOfProduct);
                XElement xProductQuantity = new XElement("Product_quantity", item.QuantityOfProduct);
                XElement xProductPrice = new XElement("Product_price", item.PriceOfProduct);
                xProduct.Add(xProductName);
                xProduct.Add(xProductIndex);
                xProduct.Add(xProductQuantity);
                xProduct.Add(xProductPrice);
                xProducts.Add(xProduct);
            }
            xOrder.Add(xProducts);
            xDoc.Element("Order_Table").Add(xOrder);
            xDoc.Save("Order.xml");
        }

        private void ListOfSendedOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TableOfProducts.ItemsSource = listOfOrders[ListOfSendedOrders.SelectedIndex].listOfProducts;
            if (listOfOrders[ListOfSendedOrders.SelectedIndex].SendedOrder == true)
            {
                TableOfProducts.IsReadOnly = true;
                SendButton.IsEnabled = false;
            }
            else
            {
                TableOfProducts.IsReadOnly = false;
                SendButton.IsEnabled = true;
            }
            //TableOfProducts.CanUserAddRows = false;
            //TableOfProducts.ca
            //ListOfSendedOrders.SelectedIndex
        }
    }
}
