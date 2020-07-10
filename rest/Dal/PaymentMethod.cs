using System.Collections.Generic;

namespace BME.DataDriven.REST.Dal
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Method { get; set; }
        public int? Deadline { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
