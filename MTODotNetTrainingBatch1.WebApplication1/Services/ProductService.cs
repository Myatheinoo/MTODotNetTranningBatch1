using Azure.Identity;
using Microsoft.Data.SqlClient;
using MTODotNetTrainingBatch1.Shared;
using MTODotNetTrainingBatch1.WebApplication1.Models;

namespace MTODotNetTrainingBatch1.WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly IDapperService _dapperService;
        public ProductService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public ResponseModel GetAllProduct()
        {
            string query = "select * from tbl_product";
            var list = _dapperService.Query<Product>(query);

            if (list.Count == 0)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Not found."
                };
            }

            var model = new ResponseModel
            {
                IsSuccess = true,
                Data = list,
                Message = "Successful"
            };
            return model;
        }
        public ResponseModel GetAllProductWithPagnigation(int pageNo, int pageSize)
        {
            string query = @"
                            select * from tbl_product 
                            order by No desc
                            Offset (@pageNo-1)*@PageSize rows Fetch next @PageSize row only";
            var result = _dapperService.Query<Product>(query, new
            {
                PageNo = pageNo,
                PageSize = pageSize
            });

            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "success",
                Data = result
            };
            return model;
        }
        public ResponseModel GetByEachProduct(int productId)
        {
            string query = "select * from tbl_product where No=@No";

            var list = _dapperService.Query<Product>(query, new
            {
                No = productId
            });

            if (list.Count == 0)
            {
                return new ResponseModel
                {
                    Message = "Not Found.",
                    IsSuccess = false
                };

            }

            var model = new ResponseModel
            {
                IsSuccess = true,
                Data = list,
                Message = "Successful."
            };
            return model;
        }
        public ResponseModel CreateProduct(Product requestModel)
        {
            if (!requestModel.Name.IsNullOrEmptyv2())
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Name field is requierd"
                };
            }
            requestModel.CreatedDateTime = DateTime.UtcNow;
            requestModel.CreatedBy = 1;
            string query = @"
                            INSERT INTO [dbo].[Tbl_Product]
                                       ([Name]
                                       ,[Code]
                                       ,[Price]
                                       ,[Quantity]
                                       ,CategoryId)
                                 VALUES
                                       (@Name
                                       ,@Code
                                       ,@Price
                                       ,@Quantity
                                       ,@CategoryId)";

            var result = _dapperService.Execute(query, requestModel);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Create success" : "Failed"
            };

            return model;
        }
        public ResponseModel UpdateProduct(int productId, Product requestModel)
        {
            requestModel.No = productId;
            #region Check fields
            string fields = string.Empty;
            if (requestModel.Name != null && !string.IsNullOrEmpty(requestModel.Name.Trim()))
            {
                fields += "[Name] = @Name,";
            }
            if (requestModel.Code != null && !string.IsNullOrEmpty(requestModel.Code.Trim()))
            {
                fields += "[Code] = @Code,";
            }
            if (requestModel.Price != null && requestModel.Quantity > 0)
            {
                fields += "[Price] = @Price,";
            }
            if (requestModel.Quantity != null && requestModel.Quantity > 0)
            {
                fields += "[Quantity] = @Quantity,";
            }
            #endregion

            #region check field length
            if (fields.Length == 0)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Fields is empty"
                };
            }
            if (fields.Length > 0)
            {
                fields = fields.Substring(0, fields.Length - 1);
            }
            #endregion

            ResponseModel model = UpdateProduct(requestModel, fields);

            return model;
        }

        private ResponseModel UpdateProduct(Product requestModel, string fields)
        {
            string query = $@"
                        UPDATE [dbo].[Tbl_Product]
                           SET {fields}
                              ,[CreatedDateTime] = @CreatedDateTime
                              ,[CreatedBy] = @CreatedBy
                         WHERE No=@No";

            var result = _dapperService.Execute(query, requestModel);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Success" : "Fail",
                Data = result
            };
            return model;
        }

        public ResponseModel DeleteProduct(int productId)
        {
            string query = @"
                            DELETE FROM [dbo].[Tbl_Product]
                                  WHERE No=@Id";
            var result = _dapperService.Execute(query, new
            {
                Id = productId
            });
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Delete Success" : "Fail"
            };

            return model;
        }
    }
}
