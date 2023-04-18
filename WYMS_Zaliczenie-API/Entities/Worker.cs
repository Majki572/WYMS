using System.Numerics;

namespace WYMS_Zaliczenie_API.Entities {
    public class Worker {
        public int WorkerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Warehouses_ID { get; set; }
        public int Vehicles_ID { get; set; }
        // Navigation properties
        public Warehouse Warehouse { get; set; }
        public Vehicle Vehicle { get; set; }
        public Worker() { }
        //

        public Worker(int wid, string email, string name, string surname, int wareID, int vehID) {
            this.WorkerId = wid;
            this.Email = email;
            this.Name = name;
            this.Surname = surname;
            this.Warehouses_ID = wareID;
            this.Vehicles_ID = vehID;
        }
    }
}
