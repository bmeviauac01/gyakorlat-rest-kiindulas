using System;
using System.Collections.Generic;

namespace BME.DataDriven.REST.Dal
{
    public partial class Order
    {
        public Order()
        {
            Invoice = new HashSet<Invoice>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Deadline { get; set; }
        public int? CustomerSiteId { get; set; }
        public int? StatusId { get; set; }
        public int? PaymentMethodId { get; set; }

        public CustomerSite CustomerSite { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Status Status { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
