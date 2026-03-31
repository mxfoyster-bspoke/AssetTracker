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
        };
        await _db.Assets.AddAsync(asset);
        await _db.SaveChangesAsync();
            
    }
}