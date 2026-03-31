using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1.Views;
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
    
    public ICommand SaveDataCommand => new AsyncRelayCommand(SaveDataAsync);
    
    private async Task SaveDataAsync()
    {
        var test = new AssetDto()
        {
            Name = ItemName,
            Description = ItemDescription,
        };

        await _testClient.AddAssetAsync(test);


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