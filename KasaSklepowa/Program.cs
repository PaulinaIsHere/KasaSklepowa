using KasaSklepowa.Model;
using KasaSklepowa.View;
using System;
using System.Collections.Generic;

class Program
{
    public static List<Product> products = new List<Product>();
   
    static void Main()
    {
        products.Add(new Product("001", " Masło extra", 6.50m));
        products.Add(new Product("002", " Chleb wiejski", 4.50m));
        products.Add(new Product("003", " Makaron Babuni", 9.20m));
        products.Add(new Product("004", " Dżem truskawkowy", 8.10m));
        products.Add(new Product("005", " Kiełbasa myśliwska", 29.0m));
        products.Add(new Product("006", " Szynka konserwowa", 22.00m));
        products.Add(new Product("007", " Chipsy paprykowe", 6.00m));
        products.Add(new Product("008", " Serek wiejski", 3.50m));
        products.Add(new Product("009", " Sól kuchenna", 2.70m));
        products.Add(new Product("010", " Cukier kryształ", 9.20m));

        int input = Display.ShowMenuAndGetChoice();
        while (input != 3)
        {
            if (input == 1)
            {
                input = Display.ShowProducts(products);
            }
            else if (input == 2)
            {
                string code;
                Cart cart = new Cart();
                code=Display.ShowProductOrReceipt(cart);
                while (code !="P")
                {
                    Console.Clear();
                    Product product = products.Find(p => p.kodKreskowy == code);
                    if (product !=null)
                    {
                        cart.products.Add(new Product(product.kodKreskowy, product.nazwa, product.cenaNetto));
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("NIEPRAWIDŁOWY KOD KRESKOWY");
                    }
                    code = Display.ShowProductOrReceipt(cart);
                }
                Console.Clear();
                Display.ShowReceipt(cart);
                break;
            }

        }
    }
}
