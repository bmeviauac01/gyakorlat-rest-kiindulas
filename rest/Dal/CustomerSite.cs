using System.Collections.Generic;

namespace BME.DataDriven.REST.Dal
{
    public partial class CustomerSite
    {
        public CustomerSite()
        {
            Customer = new HashSet<Customer>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public int? CustomerId { get; set; }

        public Customer MainCustomer { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
