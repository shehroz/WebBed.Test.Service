using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBed.Services.HotelAvailability.Services.Abstract;

namespace WebBed.Services.HotelAvailability.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        #region Hotel Search Service object
        private readonly IHotelSearchService _hotelSearchService;
        #endregion

        public HotelController(IHotelSearchService hotelSearchService)
        {
            _hotelSearchService = hotelSearchService;
        }

        #region Public method to fetch hotel and rates
        [HttpGet]
        public async Task<IActionResult> Get(int destinationId,int numberOfNights)
        {
            try
            {
                if (destinationId < 1 || numberOfNights < 1)
                    return BadRequest("Invalid Input Data");
                return Ok(await _hotelSearchService.SearchAync(destinationId, numberOfNights));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }
        #endregion
    }
}