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
    public class FollowTrainController : ControllerBase
    {
        private ICTATrainClient _ctaService;

        public FollowTrainController(ICTATrainClient ctaService)
        {
            _ctaService = ctaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FollowTrain(int id)
        {
            try
            {
                var followTrain = await _ctaService.FollowTrain(id);
                //Error handling
                return Ok(followTrain);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}