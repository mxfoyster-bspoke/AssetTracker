using System.Windows.Input;
using ClassLibrary1.Common.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1;

public class MainWindowViewModel : ObservableObject
{
    // private readonly IApiClient _apiClient;
    private readonly ITestClient  _testClient;
    //
    private string _itemName;
    private string _itemDescription;
    //
    public MainWindowViewModel(ITestClient testClient)
    {
        _testClient = testClient;
        
        LoadDataAsync();
    }
    
    private async Task LoadDataAsync()
    {
        try
        {
            // 3. Call your "Test" or "Weather" endpoint
            var result = await _testClient.GetAllAssetsAsync(); 
            //ItemName = result;
        }
        catch (Exception ex)
        {
            ItemName = "Error loading data";
        }
    }

    public ICommand SaveDataAsyncCommand => new AsyncRelayCommand(SaveDataAsync);
    private async Task SaveDataAsync()
    {
        var test = new AssetDto()
        {
            Name = "Test Name",
            Description = "Test Description",
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