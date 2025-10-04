using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTODotNetTrainingBatch1.WinFormsApp1.Query
{
    internal class ProductQuery
    {
       public static string GetAllProduct { get; } = "select * from tbl_product";
       public  static string InsertProduct { get; } = @"
INSERT INTO [dbo].[Tbl_Product]
           ([Name]
           ,[Code]
           ,[Price]
           ,[Quantity]
           ,[CreatedDateTime]
           ,[CreatedBy])
     VALUES
           (@Name
           ,@Code
           ,@Price
           ,@Quantity
           ,@CreatedDate
           ,@CurrentUser)";
    }
}
