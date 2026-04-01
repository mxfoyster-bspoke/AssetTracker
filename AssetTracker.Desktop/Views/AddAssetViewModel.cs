using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace AssetTracker.Views;
using CommunityToolkit.Mvvm.ComponentModel;


public class AddAssetViewModel : ObservableObject
{
    private readonly ITestClient  _testClient;
    private string _itemName;
    private string _itemDescription;

    public AddAssetViewModel(ITestClient testClient)
    {
        _testClient = testClient;
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

            await _testClient.AddAssetAsync(test);
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