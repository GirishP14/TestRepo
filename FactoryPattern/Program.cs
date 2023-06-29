using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var factories = new List<DiscountFactory>
            {
                new CodeDiscountFactory(Guid.NewGuid()),
                new CountryDiscountFactory("IN")
            };

            foreach (DiscountFactory disfact in factories)
            {
                var discountService = disfact.CreateDiscountService();
                Console.WriteLine($"Percentage: {discountService.DiscountPercentage}");
            }
            Console.ReadLine();
        }
    }
}
