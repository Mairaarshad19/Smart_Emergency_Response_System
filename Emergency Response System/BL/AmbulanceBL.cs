using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class AmbulanceBL
    {
        public int ambulance_id { get; set; }
        public int station_id { get; set; }
        public string plate_number { get; set; }
        public string equipment { get; set; }
        public string status { get; set; } // Available, Dispatched, OnTheWay, Busy
        public double current_latitude { get; set; }
        public double current_longitude { get; set; }
        public int EtaMinutes { get; set; }

        public AmbulanceBL() { }
        public AmbulanceBL(int ambulanceId)
        {
            this.ambulance_id = ambulanceId;
        }
        public AmbulanceBL(int stationId, string plateNumber, string equipment, string status, double latitude, double longitude)
        {
            this.station_id = stationId;
            this.plate_number = plateNumber;
            this.equipment = equipment;
            this.status = status;
            this.current_latitude = latitude;
            this.current_longitude = longitude;
        }
        public AmbulanceBL(int ambulanceId, int stationId, string plateNumber, string equipment, string status, double latitude, double longitude)
        {
            this.ambulance_id = ambulanceId;
            this.station_id = stationId;
            this.plate_number = plateNumber;
            this.equipment = equipment;
            this.status = status;
            this.current_latitude = latitude;
            this.current_longitude = longitude;
        }
        public AmbulanceBL(int ambulanceId, int stationId, string plateNumber, string equipment, string status, double latitude, double longitude, int eta)
        {
            this.ambulance_id = ambulanceId;
            this.station_id = stationId;
            this.plate_number = plateNumber;
            this.equipment = equipment;
            this.status = status;
            this.current_latitude = latitude;
            this.current_longitude = longitude;
            this.EtaMinutes = eta;
        }
        // Validation rule
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(plate_number) && !string.IsNullOrEmpty(status);
        }
    }
}