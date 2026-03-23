using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1;

public class MainWindowViewModel : ObservableObject
{
    private string _itemName;
    private string _itemDescription;

    
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