using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace KasaSklepowa.Model
{
    public class Product
    {
        public string kodKreskowy { get; set; }
        public string nazwa { get; set; }
        public decimal cenaNetto { get; set; }
        public Product(string kodKreskowy, string nazwa, decimal cenaNetto)
        {
            this.kodKreskowy = kodKreskowy;
            this.nazwa = nazwa;
            this.cenaNetto = cenaNetto;
        }
        public override string ToString() 
        {
            return  kodKreskowy + " | " + nazwa ;
        }


    }
}
