using Microsoft.AspNetCore.Mvc;
using WpfApp1.Data;
using WpfApp1.Services;

namespace WpfApp1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly AssetService _assetService;

    public TestController(AssetService assetService)
    {
        _assetService = assetService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Asset>>> GetAllAssetsAsync()
    {
        var assets = await _assetService.GetAllAssetsAsync();
        return Ok(assets);
    }
}