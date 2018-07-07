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
    public class TrainLocationsController : ControllerBase
    {
        private ICTATrainClient _ctaService;

        public TrainLocationsController (ICTATrainClient ctaService)
        {
            _ctaService = ctaService;
        }

        [HttpGet("{color}")]
        public async Task<IActionResult> GetTrainLocationsByLineColor(string color)
        {
            try 
            {
                var trainLocationss = await _ctaService.GetTrainLocations(color);
                //Error handling
                return Ok(trainLocationss);
            }
            catch(Exception ex)
            {                
                return BadRequest();
            }
        }

        public async Task<IActionResult> GetAllTrainLocations()
        {
            try 
            {
                var trainLocationss = await _ctaService.GetTrainLocations();
                //Error handling
                return Ok(trainLocationss);
            }
            catch(Exception ex)
            {                
                return BadRequest();
            }
        }   
    }
}