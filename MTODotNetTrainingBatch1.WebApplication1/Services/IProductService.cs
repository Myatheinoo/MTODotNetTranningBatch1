using MTODotNetTrainingBatch1.WebApplication1.Models;

namespace MTODotNetTrainingBatch1.WebApplication1.Services
{
    public interface IProductService
    {
        ResponseModel CreateProduct(Product requestModel);
        ResponseModel DeleteProduct(int productId);
        ResponseModel GetAllProduct();
        ResponseModel GetAllProductWithPagnigation(int pageNo, int pageSize);
        ResponseModel GetByEachProduct(int productId);
        ResponseModel UpdateProduct(int productId, Product requestModel);
    }
}