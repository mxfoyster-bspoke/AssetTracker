using ClassLibrary1.Common.DTOs;
using WpfApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Services;

public class AssetService
{
    
    private readonly AppDbContext _db;

    public AssetService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Asset>> GetAllAssetsAsync()
    {
        // This hits the SQL database and returns everything in the Assets table
        return await _db.Assets.ToListAsync();
    }


    public async Task AddAsset(AssetDto assetDto)
    {
        var asset = new Asset()
        {
            Name = assetDto.Name,
            Description = assetDto.Description,
        };
        await _db.Assets.AddAsync(asset);
        await _db.SaveChangesAsync();
            
    }
}