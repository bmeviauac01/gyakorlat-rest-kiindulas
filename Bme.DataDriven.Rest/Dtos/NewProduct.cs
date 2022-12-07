namespace Bme.DataDriven.Rest.Dtos;

public record NewProduct(string Name, double? Price, int? Stock, int VatPercentage, string CategoryName);
