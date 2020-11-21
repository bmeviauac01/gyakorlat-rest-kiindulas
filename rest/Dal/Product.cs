using System.Collections.Generic;

namespace BME.DataDriven.REST.Dal
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public int? VatId { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }

        public Category Category { get; set; }
        public VAT VAT { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
