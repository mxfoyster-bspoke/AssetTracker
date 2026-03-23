using Microsoft.AspNetCore.Mvc;

namespace WpfApp1.Controllers; // It's standard to put these in a Controllers folder

[ApiController] // This tells the framework this is a Web API
[Route("api/[controller]")] // This sets the URL to /api/test
public class TestController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World";
    }
}