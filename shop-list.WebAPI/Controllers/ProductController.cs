using AutoMapper;
using shopList.Services.Abstract;
using shopList.Services.Models;
using shopList.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace shopList.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class Product: ControllerBase
    {
        private readonly IProduct product;
        private readonly IMapper mapper;

        public ProductController(IProductService productService,IMapper mapper)
        {
            this.ProductService=productService;
            this.mapper=mapper;
        }
       
        [HttpPost]
        public IActionResult Product([FromBody] CreateProductRequest product)
        {
           var validationResult = product.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel =productService.CreateProduct(mapper.Map<CreateProduct<Model>(product));
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        
        public IActionResult GetProduct([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =ProductService.GetProduct(limit,offset);

            return Ok(mapper.Map<PageResponse<ProductResponse>>(pageModel));
        }
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            try
            {
               ProductListService.DeleteProduct(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct([FromRoute] Guid id)
        {
            try
            {
                var ProductModel =productService.GetProduct(id);
                return Ok(mapper.Map<ProductResponse>(productModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =productService.UpdateProduct(id,mapper.Map<UpdateProductModel>(model));
            return Ok(mapper.Map<ProductResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}