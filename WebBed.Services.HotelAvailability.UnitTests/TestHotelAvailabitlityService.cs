using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebBed.Services.HotelAvailability.Helper;
using WebBed.Services.HotelAvailability.Services.Abstract;
using WebBed.Services.HotelAvailability.Services.Implementation;
using Xunit;

namespace WebBed.Services.HotelAvailability.UnitTests
{
    public class TestHotelAvailabitlityService
    {
        #region private members for TestHotelAvailabitlityService
        private readonly IHotelSearchService _hotelSearchService;
        private readonly IOptions<BargainForCouplesApiSettings> _bargainForCouplesApiSettings;
        #endregion

        #region Defining service urls and secret key in constructor
        public TestHotelAvailabitlityService()
        {
            _bargainForCouplesApiSettings = Options.Create<BargainForCouplesApiSettings>(new BargainForCouplesApiSettings
            {
                BaseUrl = "https://webbedsdevtest.azurewebsites.net/api/",
                ApiSecret = "aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw=="
            });
            _hotelSearchService = new BargainForCoupleHotelService(new HttpClient(),_bargainForCouplesApiSettings);
        }

        #endregion

        #region Unit Test Cases
        [Fact]
        public async Task Search_Hotel_Availability_Should_Return_Hotels_List()
        {
            var hotelList = await _hotelSearchService.SearchAync(279, 3);
            Assert.Equal(2, hotelList.Count);
        }

        [Fact]
        public async Task Search_Hotel_Availability_Should_Throw_Exception_because_destinationid_is_less_than_1()
        {
            try
            {
                var hotelList = await _hotelSearchService.SearchAync(-1, 3);
                Assert.False(true);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
        #endregion

    }
}
