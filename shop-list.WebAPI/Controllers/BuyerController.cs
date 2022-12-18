using AutoMapper;
using shopList.Services.Abstract;
using shopList.Services.Models;
using shopList.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace shopList.WebAPI.Controllers
{

    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService buyerService;
        private readonly IMapper mapper;

          public BuyerController(IBuyerService buyerService,IMapper mapper)
        {
            this.buyerService=buyerService;
            this.mapper=mapper;
        }
    
        [HttpPost]
        public IActionResult CreateBuyer([FromBody]BuyerModel buyer)
        {
            var response =buyerService.CreateBuyer(buyer);
            return Ok(response);
        }

        
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetBuyer([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =buyerService.GetBuyer(limit,offset);

            return Ok(mapper.Map<PageResponse<BuyerResponse>>(pageModel));
        }
    
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBuyer([FromRoute] Guid id)
        {
            try
            {
                channelService.DeleteBuyer(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBuyer([FromRoute] Guid id)
        {
            try
            {
                var buyerModel =buyerService.Buyer(id);
                return Ok(mapper.Map<BayerResponse>(buyerModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateBuyer([FromRoute] Guid id, [FromBody] UpdateBuyerRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =buyerService.UpdateBuyer(id,mapper.Map<UpdateBuyerModel>(model));
            return Ok(mapper.Map<BuyerResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}