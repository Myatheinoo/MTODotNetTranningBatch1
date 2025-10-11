// See https://aka.ms/new-console-template for more information
using MTODotNetTrainingBatch1.DbShared.Models;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
var list = db.TblCategories.ToList();
foreach (var item in list)
{
    Console.WriteLine(item.Name);
}
Console.ReadLine();