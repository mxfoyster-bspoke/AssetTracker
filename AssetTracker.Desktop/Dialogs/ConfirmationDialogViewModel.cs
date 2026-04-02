using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AssetTracker.Dialogs;

public class ConfirmationDialogViewModel: ObservableObject
{
    private string _message;
    private bool _abort;
    public Action? CloseAction { get; set; }

    public ConfirmationDialogViewModel(string message)
    {
        _message = message;
    }

    public ICommand AbortCommand => new RelayCommand(ActionAbort);

    private void ActionAbort()
    {
        Abort = true;
    }
    
    
    
    public string Message 
    {
        get => _message;    
        set => SetProperty(ref _message, value);
    }
    
    public bool Abort
    {
        get => _abort;
        set => SetProperty(ref _abort, value);
    }
}