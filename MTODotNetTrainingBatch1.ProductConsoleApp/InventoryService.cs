using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTODotNetTrainingBatch1.ProductConsoleApp
{
    internal class InventoryService
    {
        public void CreateProduct()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine()!;

        BeforePrice:
            Console.Write("Enter Price: ");
            string resultPrice = Console.ReadLine()!;
            decimal price = 0;
            bool isdecimal = decimal.TryParse(resultPrice, out price);
            if (!isdecimal)
            {
                Console.WriteLine("Price is Invalid");
                goto BeforePrice;
            }

        BeforeQty:
            Console.Write("Enter Quantity: ");
            string resultQty = Console.ReadLine()!;
            int qty = 0;
            bool isInt = int.TryParse(resultQty, out qty);
            if (!isInt)
            {
                Console.WriteLine("Invalid quantity");
                goto BeforeQty;
            }

            Data.ProductId++;
            string productCode = "P" + Data.ProductId.ToString().PadLeft(3, '0');

            Product product = new Product(Data.ProductId, productCode, name, price, qty, "Fruit");
            Data.products.Add(product);
            Console.WriteLine("Product create successfully");
        }
        public void ViewProduct()
        {
            Console.WriteLine("Products List");
            foreach (var product in Data.products)
            {
                Console.WriteLine($"Name : {product.Name}, Price : {product.Price}, Quantity : {product.Quantity}");
            }
        }
        public void UpdateProduct()
        {
            BeforeProductCode:
            Console.Write("Enter product code: ");
            string code = Console.ReadLine()!;
            
            var product = Data.products.FirstOrDefault(x => x.Code == code);
            if (product is null)
            {
                Console.WriteLine("Product Not Found");
                goto BeforeProductCode;
            }
            Console.WriteLine("Product Found");
            Console.WriteLine($"Product : {product.Name}, Price : {product.Price}, Quantity : {product.Quantity}");

            BeforeQty:
            Console.Write("Enter Qunatity: ");
            string qtyResult = Console.ReadLine()!;
            int qty = 0;
            bool isInt = int.TryParse(qtyResult, out qty);
            if (!isInt)
            {
                Console.WriteLine("Quantity is invalid");
                goto BeforeQty;
            }
            product.Quantity -= qty;
            Console.WriteLine("Update product quantity successful");
        }
        public void DeleteProduct()
        {
            BeforeProductCode:
            Console.Write("Enter product code: ");
            string code = Console.ReadLine()!;
            var product = Data.products.FirstOrDefault(x => x.Code == code);
            if (product is null)
            {
                Console.WriteLine("Product Not Found");
                goto BeforeProductCode;
            }
            Console.WriteLine("Product Found");
            Console.WriteLine($"Product : {product.Name}, Price : {product.Price}, Quantity : {product.Quantity}");
            Console.WriteLine("Are you sure want to delete ? (Y/N)");
            string confirm  = Console.ReadLine()!;
            if(confirm.ToLower() == "y")
            {
                Data.products.Remove(product);
                Console.WriteLine("Delete Successful");
            }
            else
            {
                Console.WriteLine("Product not delete");

            }
        }
    }
}
