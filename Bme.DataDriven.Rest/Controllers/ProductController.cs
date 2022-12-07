using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bme.DataDriven.Rest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly Dal.DataDrivenDbContext _dbContext;

    // Az adatbazist igy kaphatjuk meg. A kornyezet adja a Dependency Injection szolgaltatast.
    // A DbContext automatikusan megszunik a keres veges (DI beallitas).
    public ProductController(Dal.DataDrivenDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public List<Dtos.Product> List([FromQuery]string search = null, [FromQuery]int from = 0)
    {
        var filteredList = string.IsNullOrEmpty(search)
            ? _dbContext.Product // ha nincs nev alapu kereses, az osszes termek
            : _dbContext.Product.Where(p => p.Name.Contains(search)); // nev alapjan kereses

        return filteredList
            .Skip(from) // lapozashoz: hanyadik termektol kezdve
            .Take(5) // egy lapon max 5 termek
            .Select(p => new Dtos.Product(p.Id, p.Name, p.Price, p.Stock)) // adatbazis entitas -> DTO
            .ToList(); // a fenti IQueryable kiertekelesesen kieroltetese, kulonben hibara futnank
    }

    [HttpGet("{id}")]
    public ActionResult<Dtos.Product> Get(int id)
    {
        var dbProduct = _dbContext.Product.SingleOrDefault(p => p.Id == id);
        return dbProduct != null
            ? Ok(new Dtos.Product(dbProduct.Id, dbProduct.Name, dbProduct.Price, dbProduct.Stock)) // siker eseten visszaadjuk az adatot magat
            : NotFound(); // 404 http valasz, ha nem talalhato a keresett elem
    }

    [HttpPost]
    public async Task<ActionResult<Dtos.Product>> Add([FromBody]Dtos.NewProduct newProduct)
    {
        var dbVat = await _dbContext.Vat.SingleOrDefaultAsync(v => v.Percentage == newProduct.VatPercentage);
        if (dbVat == null)
            dbVat = new Dal.VAT() { Percentage = newProduct.VatPercentage };

        var dbCat = await _dbContext.Category.SingleOrDefaultAsync(c => c.Name == newProduct.CategoryName);
        if (dbCat == null)
            dbCat = new Dal.Category() { Name = newProduct.CategoryName };

        var dbProduct = new Dal.Product()
        {
            Name = newProduct.Name,
            Price = newProduct.Price,
            Stock = newProduct.Stock,
            Category = dbCat,
            VAT = dbVat,
        };

        // mentes az adatbazisba
        _dbContext.Product.Add(dbProduct);
        await _dbContext.SaveChangesAsync();

        // igy mondjuk meg, hol kerdezheto le a beszurt elem
        return CreatedAtAction(
            nameof(Get),
            new { id = dbProduct.Id },
            new Dtos.Product(dbProduct.Id, dbProduct.Name, dbProduct.Price, dbProduct.Stock)); 
    }

    [HttpPut("{id}")]
    public ActionResult<Dtos.Product> Modify([FromRoute]int id, [FromBody]Dtos.Product updated)
    {
        if (id != updated.Id)
        {
            ModelState.AddModelError(nameof(id), "Nem megfelelő a kapott ID");
            return BadRequest(ModelState);
        }

        var dbProduct = _dbContext.Product.SingleOrDefault(p => p.Id == id);
        if (dbProduct == null)
            return NotFound();

        // modositasok elvegzese
        dbProduct.Name = updated.Name;
        dbProduct.Price = updated.Price;
        dbProduct.Stock = updated.Stock;

        // mentes az adatbazisban
        _dbContext.SaveChanges();

        return new Dtos.Product(dbProduct.Id, dbProduct.Name, dbProduct.Price, dbProduct.Stock);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var dbProduct = _dbContext.Product.SingleOrDefault(p => p.Id == id);
        if (dbProduct == null)
            return NotFound();

        _dbContext.Product.Remove(dbProduct);
        _dbContext.SaveChanges();

        return NoContent(); // a sikeres torlest 204 NoContent valasszal jelezzuk (lehetne meg 200 OK is, ha beletennenk an entitast)
    }
}
