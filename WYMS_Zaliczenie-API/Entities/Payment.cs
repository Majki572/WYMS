namespace WYMS_Zaliczenie_API.Entities {
    public class Payment {
        public int PaymentId { get; set; }
        public int Shops_ID { get; set; }
        public int Warehouses_ID { get; set; }
        public double PaymentValue { get; set; }
        public string? DateFrom { get; set; }
        public string? DateTo { get; set; }
        public Shop Shop { get; set; }
        public Warehouse Warehouse { get; set; }
        public Payment() { }

        public Payment(int paymentId, int shops_id, int warehouses_id, double paymentValue, string dateFrom, string dateTo) {
            this.PaymentId = paymentId;
            this.Shops_ID = shops_id;
            this.Warehouses_ID = warehouses_id;
            this.PaymentValue= paymentValue;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }
    }
}
