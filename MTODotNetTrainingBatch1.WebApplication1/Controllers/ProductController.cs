using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using MTODotNetTrainingBatch1.Shared;
using MTODotNetTrainingBatch1.WebApplication1.Models;
using MTODotNetTrainingBatch1.WebApplication1.Services;

namespace MTODotNetTrainingBatch1.WebApplication1.Controllers
{
    // https://localhost:7064/api/product
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProduct")]
        public IActionResult GetAllProduct()
        {
            var result = _productService.GetAllProduct();
           
            return Ok(result);
        }
        [HttpGet("GetAllProductWithPagination")]
        public IActionResult GetAllProductWithPagnigation(int pageNo, int pageSize)
        {
            var result = _productService.GetAllProductWithPagnigation(pageNo, pageSize);
            return Ok(result);
        }
        [HttpGet("GetByEachProduct/{productId}")]
        public IActionResult GetByEachProduct(int productId)
        {
           var result = _productService.GetByEachProduct(productId);
            if (result.IsSuccess == false)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
           Console.WriteLine("Create Product =>" + product.ToJson());
           var result = _productService.CreateProduct(product);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult CreateOrUpdateProduct()
        {
            return Ok("CreateOrUpdateProduct");
        }

        [HttpPatch("UpdateProduct/{productId}")]
        public IActionResult UpdateProduct(int productId, Product product)
        {
           var model = _productService.UpdateProduct(productId, product);
            if(model.IsSuccess == false)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpDelete("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var model = _productService.DeleteProduct(productId);
            return Ok(model);
        }
    }
}
