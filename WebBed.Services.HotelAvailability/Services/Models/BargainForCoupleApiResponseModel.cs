using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBed.Services.HotelAvailability.Services.Models
{
    public class BargainForCoupleApiResponseModel
    {
        #region Bargain for Couple Api Response Objects
        public Hotel hotel { get; set; }
        public List<Rate> rates { get; set; }
        #endregion

    }
    public class Hotel
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
    }
    public class Rate
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public double value { get; set; }
    }
}
