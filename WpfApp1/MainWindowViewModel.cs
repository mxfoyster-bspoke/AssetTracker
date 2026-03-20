using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private string _title = "Item Name!";

    public string Title
    {
        get => _title;
        set 
        { 
            _title = value; 
            OnPropertyChanged(); 
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}