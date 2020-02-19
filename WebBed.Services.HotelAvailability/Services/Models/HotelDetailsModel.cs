using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBed.Services.HotelAvailability.Services.Models
{
    #region API Response Objects
    public class HotelDetailsModel
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
        
        public List<RateDetailModel> Rates { get; set; }
    }
    #endregion
    public class RateDetailModel
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public double FinalPrice { get; set; }
    }

}
