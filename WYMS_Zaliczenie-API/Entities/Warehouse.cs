namespace WYMS_Zaliczenie_API.Entities {
    public class Warehouse {
        public int WarehouseId { get; set; }
        public string Address { get; set; }
        public string Surface { get; set; }
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public Warehouse() { }
        public Warehouse(int wid, string address, string surface) {
            this.WarehouseId = wid;
            this.Address = address;
            this.Surface = surface;
        }
    }
}
