using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebBed.Services.HotelAvailability.Helper;
using WebBed.Services.HotelAvailability.Services.Abstract;
using WebBed.Services.HotelAvailability.Services.Models;

namespace WebBed.Services.HotelAvailability.Services.Implementation
{
    public class BargainForCoupleHotelService : IHotelSearchService
    {
        #region private members for Bargain For Couple Service
        private HttpClient _client { get; }
        private readonly BargainForCouplesApiSettings _apiSettings;
        private const string RateTypePerNightKey = "PerNight";
        #endregion

        public BargainForCoupleHotelService(HttpClient httpClient, IOptions<BargainForCouplesApiSettings> bargainApiSettings)
        {
            _apiSettings = bargainApiSettings.Value;
            _client = httpClient;

            #region setting up http client
            httpClient.BaseAddress = new Uri(_apiSettings.BaseUrl);
            _client = httpClient;
            #endregion

        }

        #region Main Search criteria and connectivity with Bargain for Couples API
        public async Task<List<HotelDetailsModel>> SearchAync(int destinationId, int numberOfNights)
        {
            try
            {
                if (destinationId < 1 || numberOfNights < 1)
                    throw new ArgumentException("Invalid Data");
                var response = await _client.GetAsync($"findBargain?destinationId={destinationId}&nights={numberOfNights}&code={_apiSettings.ApiSecret}");
                response.EnsureSuccessStatusCode();
                string apiResponse = await response.Content.ReadAsStringAsync();
                var ListOfHotels = JsonConvert.DeserializeObject<List<BargainForCoupleApiResponseModel>>(apiResponse);

                return ListOfHotels.Select(h => new HotelDetailsModel
                {
                    geoId = h.hotel.geoId,
                    name = h.hotel.name,
                    propertyID = h.hotel.propertyID,
                    rating = h.hotel.rating,
                    Rates = h.rates.Select(r => new RateDetailModel
                    {
                        boardType = r.boardType,
                        rateType = r.rateType,
                        FinalPrice = r.rateType.Equals(RateTypePerNightKey) ? r.value * numberOfNights : r.value
                    }).ToList()
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
