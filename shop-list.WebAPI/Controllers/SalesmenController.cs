using AutoMapper;
using shopList.Services.Abstract;
using shoplist.Services.Models;
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
    public class SalesmenController : ControllerBase
    {
        private readonly ISalesmenService salesmenService;
        private readonly IMapper mapper;

        public SalesmenController(ISalesmenService salesmenService,IMapper mapper)
        {
            this.salesmenService=salesmenService;
            this.mapper=mapper;
        }
        [HttpPost]
        public IActionResult CreateSalesmen([FromBody] CreateSalesmenRequest salesmen)
        {
            var validationResult = salesmen.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel =salesmenService.CreateSalesmen(mapper.Map<CreateSalesmenModel>(salesmen));
                return Ok(resultModel);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        
        public IActionResult GetSalesmen([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = salesmenService.GetSalesmen(limit,offset);

            return Ok(mapper.Map<PageResponse<SalesmenResponse>>(pageModel));
        }
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSalesmen([FromRoute] Guid id)
        {
            try
            {
                salesmenService.DeleteSalesmen(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSalesmen([FromRoute] Guid id)
        {
            try
            {
                var salesmenModel = salesmenService.GetSalesmen(id);
                return Ok(mapper.Map<SalesmenResponse>(salesmenModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateSalesmen([FromRoute] Guid id, [FromBody] UpdateSalesmenRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =salesmenService.UpdateSalesmen(id,mapper.Map<UpdateSalesmenModel>(model));
            return Ok(mapper.Map<SalesmenResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}