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
    public class ProductInStock: ControllerBase
    {
        private readonly IProductInStock productInStock;
        private readonly IMapper mapper;

        public ProductInStockController(IProductInStockService productInStockService,IMapper mapper)
        {
            this.ProductInStockService=productInStockService;
            this.mapper=mapper;
        }
       
        [HttpPost]
        public IActionResult ProductInStock([FromBody] CreateProductInStockRequest productInStock)
        {
           var validationResult = productInStock.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel =productInStockService.CreateProductInStock(mapper.Map<CreateProductInStockModel>(productInStock));
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        
        public IActionResult GetProductInStock([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =ProductInStockService.GetProductInStock(limit,offset);

            return Ok(mapper.Map<PageResponse<ProductInStockResponse>>(pageModel));
        }
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProductInStock([FromRoute] Guid id)
        {
            try
            {
               ProductInStockService.DeleteProductInStock(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductInStock([FromRoute] Guid id)
        {
            try
            {
                var ProductListModel =productInStockService.GetProductInStock(id);
                return Ok(mapper.Map<ProductInStockResponse>(productInStockModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProductInStock([FromRoute] Guid id, [FromBody] UpdateProductInStockRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =productInStockService.UpdateProductInStock(id,mapper.Map<UpdateProductInStockModel>(model));
            return Ok(mapper.Map<ProductInStockResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}