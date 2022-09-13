using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodDonation.DataAccess;
using FoodDonation.Models;
using FoodDonation.Repository;

namespace FoodDonation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDonorModelsController : ControllerBase
    {
        private readonly IFoodDonorRepository _fooddonorRepo;

        public FoodDonorModelsController([FromBody] IFoodDonorRepository fooddonorRepository)
        {
            _fooddonorRepo = fooddonorRepository;
        }

            // GET: api/FoodDonorModels
            [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _fooddonorRepo.GetType();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(FoodDonorModels employees)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _fooddonorRepo.Post(employees);
                    return StatusCode(200, result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }



        }

        [HttpPut("Put")]
        public async Task<IActionResult> put([FromBody] FoodDonorModels employees)
        {
            try
            {
                var result = _fooddonorRepo.Put(employees);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = _fooddonorRepo.Delete(Id);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
      
    }
}
