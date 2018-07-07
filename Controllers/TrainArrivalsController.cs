using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using CTAAPIWrapper.Services;
using CTAAPIWrapper.Models;


namespace CTAAPIWrapper.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class TrainArrivalsController : ControllerBase
    {
        private ICTATrainClient _ctaService;

        public TrainArrivalsController (ICTATrainClient ctaService)
        {
            _ctaService = ctaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainArrivals(int id)
        {
            try 
            {            
                if ( id > 49999 ||  id < 30000  )
                {
                    return BadRequest("Station or stop does not exist");
                }

                var trainArrivals = await _ctaService.GetTrainArrivals(id);
                //Error handling
                return Ok(trainArrivals.ETAs);
            }
            catch(Exception ex)
            {                
                return BadRequest();
            }
        }        
    }
}