using System.Windows;

namespace WpfApp1;

public interface IDialogService
{
    void ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : class;
}

public class DialogService : IDialogService
{
    public void ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : class
    {
        // This maps the ViewModel to a Window. 
        // For simplicity, we create a generic Window to host the UserControl.
        var view = new Window
        {
            Content = viewModel,
            SizeToContent = SizeToContent.WidthAndHeight,
            WindowStartupLocation = WindowStartupLocation.CenterScreen
        };

        view.ShowDialog();
    }
}