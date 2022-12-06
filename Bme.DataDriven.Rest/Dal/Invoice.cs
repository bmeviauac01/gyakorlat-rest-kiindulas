namespace Bme.DataDriven.Rest.Dal;

public partial class Invoice
{
    public Invoice()
    {
        InvoiceItems = new HashSet<InvoiceItem>();
    }

    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerZipCode { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerStreet { get; set; }
    public int? PrintedCopies { get; set; }
    public bool? Cancelled { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public DateTime? PaymentDeadline { get; set; }
    public int? InvoiceIssuerId { get; set; }
    public int? OrderId { get; set; }

    public InvoiceIssuer InvoiceIssuer { get; set; }
    public Order Order { get; set; }
    public ICollection<InvoiceItem> InvoiceItems { get; set; }
}
