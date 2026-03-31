using ClassLibrary1.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<List<AssetDto>>> GetAllAssetsAsync()
    {
        var assets = await _assetService.GetAllAssetsAsync();
        return Ok(assets);
    }


    [HttpPost]
    public async Task AddAsset(AssetDto assetDto)
    {
        await _assetService.AddAsset(assetDto);
    }
}