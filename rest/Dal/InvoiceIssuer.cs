using System.Collections.Generic;

namespace BME.DataDriven.REST.Dal
{
    public partial class InvoiceIssuer
    {
        public InvoiceIssuer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string TaxIdentifier { get; set; }
        public string BankAccount { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
