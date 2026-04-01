namespace AssetTracker.Data;

public class Asset
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateDeleted { get; set; }
}