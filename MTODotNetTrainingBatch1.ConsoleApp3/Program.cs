// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MTODotNetTrainingBatch1.ConsoleApp3;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();

// select Category
var list = db.ProductCategories.ToList();
foreach (var item in list)
{
    Console.WriteLine(item.Name);
}

// Add Category
//var category = new ProductCategory
//{
//    Code = "C002",
//    Name = "Vegtables"
//};

//db.ProductCategories.Add(category);

//int result = db.SaveChanges();

// Update Cagteory
//var category = db.ProductCategories.FirstOrDefault(x => x.CategoryId == 3);
//if(category is null)
//{
//    Console.WriteLine("item not found.");
//    return;
//}

//category.Code = "C003";
//category.Name = "Foods";

//var result = db.SaveChanges();

// Delete
//var category = db.ProductCategories.FirstOrDefault(x => x.CategoryId == 3);
//if(category is null)
//{
//    Console.WriteLine("Item not found.");
//    return;
//}

//db.ProductCategories.Remove(category);
//db.SaveChanges();

Console.ReadLine();