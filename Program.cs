using System;
using System.Collections.Generic;
using System.Globalization;
using Product.Entities;

namespace Product
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int numProds = int.Parse(Console.ReadLine());
            List<CommonProduct> ProdList = new List<CommonProduct>();
            

            for (int i = 1; i <= numProds; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char prodType = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                if (prodType == 'c' || prodType == 'C')
                {
                    ProdList.Add(new CommonProduct(name, price));
                }
                else if (prodType == 'u' || prodType == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    ProdList.Add(new UsedProduct(name, price, date));
                }
                else if (prodType == 'i' || prodType == 'I')
                {
                    Console.Write("Customs fee: ");
                    double fee = double.Parse(Console.ReadLine());
                    ProdList.Add(new ImportedProduct(name, price, fee));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (CommonProduct prod in ProdList)
            {
                Console.WriteLine(prod.PriceTag());
            }

        }
    }
}
