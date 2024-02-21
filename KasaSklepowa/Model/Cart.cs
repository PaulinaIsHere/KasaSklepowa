using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasaSklepowa.Model
{
    public class Cart
    {
        public List<Product> products { get; set; }

        public Cart() 
        {
            products = new List<Product>();
        }
        public decimal GetTotalAmount () 
        {
        decimal total = 0;
            foreach (var product in products)
            {
                total += product.cenaNetto;
            }
            return total;
        }
       public decimal GetBruttoTotalAmount () 
        {
        return Math.Round(GetTotalAmount()*1.23m, 2);
        }
        public decimal GetVat()
        {
            return GetBruttoTotalAmount()-GetTotalAmount();
        }
    }
}
