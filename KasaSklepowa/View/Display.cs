using KasaSklepowa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KasaSklepowa.View

{
    public static class Display
    {
        static bool IsNumber(string input)
        {
            return int.TryParse(input, out _);
        }
        public static int ShowMenuAndGetChoice()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Witaj w sklepie wirtualnym!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1.LISTA WSZYSTKICH ZAKUPÓW");
            Console.WriteLine("2.ZAKUPY");
            Console.WriteLine("3.ZAKOŃCZ PROGRAM");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" WYBIERZ 1, 2 LUB 3:");
            while (true)
            {
                var answer = Console.ReadLine();
                if (IsNumber(answer))
                {
                    int parsedAnswer = int.Parse(answer);
                    if (parsedAnswer >= 1 && parsedAnswer <= 3)
                    {
                        return parsedAnswer;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Wprowadź poprawną wartość (1, 2 lub 3)!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Niepoprawna wartość. Podaj liczbę.");
                }
            }
        }
        public static int ShowProducts(List<Product> products)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("KOD KRESKOWY  |  NAZWA");

            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
            return ShowMenuAndGetChoice();
        }
        public static string ShowProductOrReceipt(Cart cart)
        {

            if (cart.products.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(cart.products.Last().ToString());
                Console.WriteLine("CENA ŁĄCZNA: " + cart.GetTotalAmount() + "zł");
            }
            Console.WriteLine("KOD KRESKOWY LUB WYDRUK PARAGONU(P):");
            return Console.ReadLine();
        }
        public static void ShowReceipt(Cart cart)
        {
            Console.WriteLine("__________________________________");
            Console.WriteLine("PARAGON");
            Console.WriteLine("DATA ZAKUPU:" + DateTime.Now.ToString());
            Console.WriteLine("__________________________________");
            foreach (var product in cart.products)
            {
                Console.WriteLine(product.nazwa + " | " + product.cenaNetto + " zł");
            }
            Console.WriteLine("__________________________________");
            Console.WriteLine("DO ZAPŁATY: " + cart.GetBruttoTotalAmount());
            Console.WriteLine("W TYM VAT: " + cart.GetVat());
            Console.WriteLine("__________________________________");
        }
    }

}
