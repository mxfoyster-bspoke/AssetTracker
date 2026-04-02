using CommunityToolkit.Mvvm.ComponentModel;

namespace AssetTracker.Dialogs;

public class ConfirmationDialogViewModel: ObservableObject
{
    private string _message;

    public ConfirmationDialogViewModel(string message)
    {
        _message = message;
    }
    
    
    public string Message 
    {
        get => _message;    
        set => SetProperty(ref _message, value);
    }
}