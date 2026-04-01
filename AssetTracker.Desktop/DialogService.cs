using System.Windows;
using AssetTracker.Views;

namespace AssetTracker;

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

        if (viewModel is AddAssetViewModel vm)
        {
            vm.CloseAction = () => view.Close();
        }
        view.ShowDialog();
    }
}