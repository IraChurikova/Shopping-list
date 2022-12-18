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
    public class DescriptionController : ControllerBase
    {
        private readonly IDescriptionService descriptionService;
        private readonly IMapper mapper;

          public BuyerController(IDescriptionService descriptionService,IMapper mapper)
        {
            this.descriptionService=descriptionService;
            this.mapper=mapper;
        }
    
        [HttpPost]
        public IActionResult CreateDescription([FromBody]BuyerModel buyer)
        {
            var response =descriptionService.CreateDescription(description);
            return Ok(response);
        }

        
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult GetBuyer([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel =descriptionService.GetDescription(limit,offset);

            return Ok(mapper.Map<PageResponse<DescriptionResponse>>(pageModel));
        }
    
    
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDescription([FromRoute] Guid id)
        {
            try
            {
                channelService.DeleteDescription(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDescription([FromRoute] Guid id)
        {
            try
            {
                var descriptionModel = descriptionService.Description(id);
                return Ok(mapper.Map<DescriptionResponse>(descriptionModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateDescription([FromRoute] Guid id, [FromBody] UpdateDescriptionRequest model)
        {
           var validationResult =model.Validate();
           if(!validationResult.IsValid)
           {
            return BadRequest(validationResult.Errors);
           }
           try
           {
            var resultModel =descriptionService.UpdateDescription(id,mapper.Map<UpdateDescriptionModel>(model));
            return Ok(mapper.Map<DescriptionResponse>(resultModel));
           }
           catch(Exception ex)
           {
            return BadRequest(ex.ToString());
           }
        }
          
    }

}