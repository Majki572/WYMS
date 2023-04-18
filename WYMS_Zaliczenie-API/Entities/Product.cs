namespace WYMS_Zaliczenie_API.Entities {
    public class Product {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Warehouses_ID { get; set; }
        public int Quantity { get; set; }
        public Warehouse Warehouse { get; set; }
        public Product() { }
        public Product(int pid, string name, int warID, int quantity) {
            this.ProductId = pid;
            this.Name = name;
            this.Warehouses_ID = warID;
            this.Quantity = quantity;
        }
    }
}
