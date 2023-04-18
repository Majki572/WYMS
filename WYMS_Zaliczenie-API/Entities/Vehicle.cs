namespace WYMS_Zaliczenie_API.Entities {
    public class Vehicle {
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public double Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public int Warehouses_ID { get; set; }
        public int Schedules_ID { get; set; }
        public Warehouse Warehouse { get; set; }
        public Schedule Schedule { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public Vehicle() { }
        public Vehicle(int vid, string type, double capacity, bool isavailable, int warID, int schID) {
            this.VehicleId = vid;
            this.Type = type;
            this.Capacity = capacity;
            this.IsAvailable = isavailable;
            this.Warehouses_ID = warID;
            this.Schedules_ID = schID;
        }

    }
}
