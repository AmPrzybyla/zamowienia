using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zamowienia
{
    public class Order
    {
        public ObservableCollection<Product> listOfProducts = new ObservableCollection<Product>(); 
        public string Address { get; set; }
        public string Company { get; set; }
        public DateTime Date { get; set; }
        public double PriceOfOrder { get; set; }
        public bool SendedOrder { get; set; }
    }
}
