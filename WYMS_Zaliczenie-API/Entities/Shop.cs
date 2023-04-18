namespace WYMS_Zaliczenie_API.Entities {
    public class Shop {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Schedules_ID { get; set; }
        public Schedule Schedule { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public Shop() { }
        public Shop(int shopid, string name, string address, int schID) {
            this.ShopId = shopid;
            this.Name = name;
            this.Address = address;
            this.Schedules_ID = schID;
        }
    }
}
