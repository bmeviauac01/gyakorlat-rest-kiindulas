using Microsoft.AspNetCore.Mvc;

namespace Bme.DataDriven.Rest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HelloController : ControllerBase
{
    // 2. alfeladat
    //[HttpGet]
    //public string Hello()
    //{
    //    return "Hello!";
    //}

    // 3. alfeladat
    [HttpGet]
    public string Hello([FromQuery] string name)
    {
        return string.IsNullOrEmpty(name)
            ? "Hello noname!"
            : $"Hello {name}";
    }

    // 4. alfeladat
    [HttpGet("{personName}")] // a route-ban a {} közötti név meg kell egyezzen a paraméter nevével
    public string HelloRoute(string personName)
    {
        return "Hello route " + personName;
    }
}
