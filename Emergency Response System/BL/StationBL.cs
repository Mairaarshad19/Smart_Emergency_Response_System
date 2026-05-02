using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.DL;
using System.Xml.Linq;

namespace Emergency_Response_System.BL
{
    public class StationBL
    {
        public int station_id { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string plate_no { get; set; }
        public DateTime created_at { get; set; }
        public int IntersectionId { get; set; }

        // Default constructor
        public StationBL() { }

        public StationBL(int id, string name, int intersectionId)
        {
            this.station_id = id;
            this.name = name;
            IntersectionId = intersectionId;
        }

        // Constructor for new station (without ID, auto-generated in DB)
        public StationBL(string name, double latitude, double longitude)
        {
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        // Constructor with ID (for existing stations)
        public StationBL(int stationId, string name, double latitude, double longitude, DateTime createdAt)
        {
            this.station_id = stationId;
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
            this.created_at = createdAt;
        }

        public StationBL(int stationId, string name, double latitude, double longitude, string plateno)
        {
            this.station_id = stationId;
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
            this.plate_no = plateno;
        }
        public StationBL(int stationId, string name, double latitude, double longitude, DateTime createdAt , int intersectionId)
        {
            this.station_id = stationId;
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
            this.created_at = createdAt;
            this.IntersectionId = intersectionId;
        }

        // Validation method
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(name) &&
                   latitude != 0 &&
                   longitude != 0;
        }
    }
}
