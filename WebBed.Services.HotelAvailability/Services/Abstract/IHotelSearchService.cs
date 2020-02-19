using System.Collections.Generic;
using System.Threading.Tasks;
using WebBed.Services.HotelAvailability.Services.Models;

namespace WebBed.Services.HotelAvailability.Services.Abstract
{
    public interface IHotelSearchService
    {
        #region search method interface based on destinationId and number of nights
        Task<List<HotelDetailsModel>> SearchAync(int destinationId, int numberOfNights);
        #endregion
    }
}
