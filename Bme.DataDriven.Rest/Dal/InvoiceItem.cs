namespace Bme.DataDriven.Rest.Dal;

public partial class InvoiceItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Amount { get; set; }
    public double? Price { get; set; }
    public int? Vatpercentage { get; set; }
    public int? InvoiceId { get; set; }
    public int? OrderItemId { get; set; }

    public Invoice Invoice { get; set; }
    public OrderItem OrderItem { get; set; }
}
