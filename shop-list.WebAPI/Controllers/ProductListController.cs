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
    public class ProductList: ControllerBase
    {
        private readonly IProductList productList;
        private readonly IMapper mapper;

        public ProductListController(IProductListtService productListService,IMapper mapper)
        {
            this.ProductListService=productListService;
            this.mapper=mapper;
        }
       
        [HttpPost]
        public IActionResult ProductList([FromBody] CreateProductListRequest productList)
        {
           var validationResult = productList.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel =productListService.CreateProductList(mapper.Map<CreateProductListModel>(productList));
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        
        public IActionResult GetProductList([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =ProductListService.GetProductList(limit,offset);

            return Ok(mapper.Map<PageResponse<ProductListResponse>>(pageModel));
        }
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProductList([FromRoute] Guid id)
        {
            try
            {
               ProductListService.DeleteProductList(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductList([FromRoute] Guid id)
        {
            try
            {
                var ProductListModel =productListService.GetProductList(id);
                return Ok(mapper.Map<ProductListResponse>(productListModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProductList([FromRoute] Guid id, [FromBody] UpdateProductListRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =productListService.UpdateProductList(id,mapper.Map<UpdateProductListModel>(model));
            return Ok(mapper.Map<ProductListResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}