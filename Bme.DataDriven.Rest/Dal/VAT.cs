namespace Bme.DataDriven.Rest.Dal;

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
