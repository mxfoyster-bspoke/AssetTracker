using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1;

public class MainWindowViewModel : ObservableObject
{
    private string _itemName;
    private string _itemDescription;

    private string _title = "Item Name!";

    public string Title
    {
        get => _title;

        set => SetProperty(ref _title, value);
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