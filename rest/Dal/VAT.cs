using System.Collections.Generic;

namespace BME.DataDriven.REST.Dal
{
    public partial class VAT
    {
        public VAT()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? Percentage { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
