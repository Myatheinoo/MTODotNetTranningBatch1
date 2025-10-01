using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTODotNetTrainingBatch1.ProductConsoleApp
{
    internal class Data
    {
        public static int ProductId = 2;
        public static List<Product> products = new List<Product>()
        {
            new Product(1,"P001","Apple",2000,10,"Fruit"),
            new Product(2,"P002","Orange",2000,100,"Fruit")
        };
    }
}
