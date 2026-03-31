using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1;

public class MainWindowViewModel : ObservableObject
{
    // private readonly IApiClient _apiClient;
    private readonly ITestClient  _testClient;
    //
    private List<AssetViewModel> _items;
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
            var result = await _testClient.GetAllAssetsAsync(); 
            Items = result.Select(s=> new AssetViewModel()
            {
                ItemName = s.Name,
                ItemDescription = s.Description
            }).ToList();
        }
        catch (Exception ex)
        {
            //ItemName = "Error loading data";
        }
    }
    
    public ICommand AddAssetCommand => new RelayCommand(AddAsset);

    private void AddAsset()
    {
        
    }

    public List<AssetViewModel> Items
    {
        get => _items;
        set => SetProperty(ref _items, value);
    }
    
    public class AssetViewModel : ObservableObject
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; } 
        
    }
}