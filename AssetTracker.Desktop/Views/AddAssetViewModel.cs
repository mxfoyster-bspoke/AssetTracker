using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp1;

namespace AssetTracker.Views;
using CommunityToolkit.Mvvm.ComponentModel;


public class AddAssetViewModel : ObservableObject
{
    private readonly IAssetClient  _assetClient;
    private string _itemName;
    private string _itemDescription;

    public AddAssetViewModel(IAssetClient assetClient)
    {
        _assetClient = assetClient;
    }
    
    public Action? CloseAction { get; set; }
    public ICommand SaveDataCommand => new AsyncRelayCommand(SaveDataAsync);
    
    private async Task SaveDataAsync()
    {
        try
        {
            var test = new AssetDto()
            {
                Name = ItemName,
                Description = ItemDescription,
            };

            await _assetClient.AddAssetAsync(test);
            CloseAction?.Invoke();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
      

    }
    
    public string ItemName
    {
        get => _itemName;
        set => SetProperty(ref _itemName, value);
    }
    
    public string ItemDescription 
    {
        get => _itemDescription;    
        set => SetProperty(ref _itemDescription, value);
    }
}