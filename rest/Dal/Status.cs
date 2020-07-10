using System.Collections.Generic;

namespace BME.DataDriven.REST.Dal
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
