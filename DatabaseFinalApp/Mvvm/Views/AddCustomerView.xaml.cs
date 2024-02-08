using DatabaseFinalApp.Mvvm.ViewModels;
using System.Windows.Controls;


namespace DatabaseFinalApp.Mvvm.Views;


public partial class AddCustomerView : Page
{
    public AddCustomerView(AddCustomerViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
