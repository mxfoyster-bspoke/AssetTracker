using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1;

public class MainWindowViewModel : ObservableObject
{
    private readonly IApiClient _apiClient;
    
    private string _itemName;
    private string _itemDescription;

    public MainWindowViewModel(IApiClient apiClient)
    {
        _apiClient = apiClient;
        LoadDataAsync();
    }
    
    private async Task LoadDataAsync()
    {
        try
        {
            // 3. Call your "Test" or "Weather" endpoint
            var result = await _apiClient.GetInventoryAsync(); 
            //ItemName = result;
        }
        catch (Exception ex)
        {
            ItemName = "Error loading data";
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