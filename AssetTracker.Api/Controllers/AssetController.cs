using AssetTracker.Common.DTOs;
using AssetTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetController : ControllerBase
{
    private readonly AssetService _assetService;

    public AssetController(AssetService assetService)
    {
        _assetService = assetService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<AssetDto>>> GetAllAssetsAsync()
    {
        var assets = await _assetService.GetAllAssetsAsync();
        return Ok(assets);
    }
    
    [HttpPost("add")] 
    public async Task AddAsset(AssetDto assetDto)
    {
        await _assetService.AddAsset(assetDto);
    }
    
    [HttpPost("delete/{idToDelete}")]
    public async Task DeleteAsset(int idToDelete)
    {
        await _assetService.DeleteAsset(idToDelete);
    }
}