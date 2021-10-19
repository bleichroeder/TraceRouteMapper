using TraceRouteMapper.Contracts;

namespace TraceRouteMapper
{
    public class GeoLocation
    {
        public string Country_Code { get; set; } = "-";
        public string Hostname { get; set; } = "-";
        public string Continent_Code { get; set; } = "-";
        public string Continent { get; set; } = "-";
        public string Country_Name { get; set; } = "-";
        public string City { get; set; } = "-";
        public string Region_Name { get; set; } = "-";
        public string Zip { get; set; } = "-";
        public string Latitude { get; set; } = "-";
        public string Longitude { get; set; } = "-";
        public string IP { get; set; } = "-";
        public string Country_Flag { get; set; } = null;

        public bool HasLocationData()
        {
            return Longitude.ToLower() != "-" && Latitude.ToLower() != "-";
        }
    }
}
