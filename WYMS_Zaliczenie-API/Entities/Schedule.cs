namespace WYMS_Zaliczenie_API.Entities {
    public class Schedule {
        public int ScheduleId { get; set; }
        public int Warehouses_ID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection<Shop> Shops { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public Schedule() { }
        public Schedule(int scheduleID, int warID, string dfrom, string dto) {
            this.ScheduleId = scheduleID;
            this.Warehouses_ID = warID;
            this.DateFrom = dfrom;
            this.DateTo = dto;
        }
    }
}
