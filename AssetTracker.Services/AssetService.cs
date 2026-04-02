using AssetTracker.Common.DTOs;
using AssetTracker.Data;
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
        return await _db.Assets
            .Where(w=> w.DateDeleted == null)
            .Select(s=> new AssetDto()
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            DateAdded = s.DateAdded
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

    public async Task DeleteAsset(int idToDelete)
    {
        var assetToDelete = await _db.Assets.FirstOrDefaultAsync(s => s.Id == idToDelete);
        if (assetToDelete == null)
        {
            return;
        }
        
        assetToDelete.DateDeleted = DateTime.UtcNow; ;
        await _db.SaveChangesAsync();
    }
}