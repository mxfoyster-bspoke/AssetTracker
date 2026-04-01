using AssetTracker.Data;
using ClassLibrary1.Common.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker.Services;

public class AssetService
{
    
    private readonly AppDbContext _db;

    public AssetService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<AssetDto>> GetAllAssetsAsync()
    {
        return await _db.Assets.Select(s=> new AssetDto()
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
        }).ToListAsync();
    }


    public async Task AddAsset(AssetDto assetDto)
    {
        var asset = new Asset()
        {
            Name = assetDto.Name,
            Description = assetDto.Description,
            DateAdded = DateTime.UtcNow,
        };
        await _db.Assets.AddAsync(asset);
        await _db.SaveChangesAsync();
            
    }
}