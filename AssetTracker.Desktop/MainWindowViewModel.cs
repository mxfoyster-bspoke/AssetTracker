using System.Windows.Input;
using AssetTracker.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp1;

namespace AssetTracker;

public class MainWindowViewModel : ObservableObject
{
    // private readonly IApiClient _apiClient;
    private readonly IAssetClient  _assetClient;
    private readonly IDialogService _dialogService;
    //
    private List<AssetViewModel> _items;
    //
    public MainWindowViewModel(IAssetClient assetClient, IDialogService dialogService)
    {
        _assetClient = assetClient;
        _dialogService = dialogService;

        LoadDataAsync();
    }
    
    private async Task LoadDataAsync()
    {
        try
        {
            var result = await _assetClient.GetAllAssetsAsync(); 
            Items = result.Select(s=> new AssetViewModel()
            {
                Id = s.Id.Value,
                ItemName = s.Name,
                ItemDescription = s.Description,
                DateAdded = s.DateAdded.Value
            }).ToList();
        }
        catch (Exception ex)
        {
            //ItemName = "Error loading data";
        }
    }
    
    public ICommand AddAssetCommand => new AsyncRelayCommand(AddAsset);

    private async Task AddAsset()
    {
        var vm = new AddAssetViewModel(_assetClient);
        _dialogService.ShowDialog(vm);
        await LoadDataAsync();
    }

    public ICommand DeleteAssetCommand => new AsyncRelayCommand<object?>(DeleteAsset);

    private async Task DeleteAsset(object? parameter)
    {
        var asset = parameter as AssetViewModel;
        
        if (asset == null) 
            return;

        try 
        {
            await _assetClient.DeleteAssetAsync(asset.Id);
            
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Delete failed: {ex.Message}");
        }
        
        await LoadDataAsync();
    }

    public List<AssetViewModel> Items
    {
        get => _items;
        set => SetProperty(ref _items, value);
    }
    
    public class AssetViewModel : ObservableObject
    {
        public int Id  { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public DateTime DateAdded { get; set; }
        
    }
}