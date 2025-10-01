
using MTODotNetTrainingBatch1.ProductConsoleApp;

Console.WriteLine("Inventory Management System");
BeforeSystem:
InventoryService productService = new InventoryService();
Console.WriteLine("Choose Option:");
Console.WriteLine("1. Create Product");
Console.WriteLine("2. View Product");
Console.WriteLine("3. Update Product");
Console.WriteLine("4. Delete Product");
Console.WriteLine("5. Exit");
int option = int.Parse(Console.ReadLine()!);
switch (option)
{
    case 1:
        Console.WriteLine("Create Product");
        productService.CreateProduct(); 
        break;
    case 2:
        Console.WriteLine("View Product");
        productService.ViewProduct();
        break;
    case 3:
        Console.WriteLine("Update Product");
        productService.UpdateProduct();
        break;
    case 4:
        Console.WriteLine("Delete Product");
        productService.DeleteProduct();
        break;
    case 5:
        Console.WriteLine("Exiting...");
        goto Exit;
     default:Console.WriteLine("Invalid option. Please Enter valid option");
        break;
}
goto BeforeSystem;
Exit:
Console.ReadKey();

//Console.ReadLine();