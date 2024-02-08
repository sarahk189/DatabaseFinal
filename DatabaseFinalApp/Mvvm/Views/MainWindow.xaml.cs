using Infrastructure.Dtos;
using System.Windows;

namespace DatabaseFinalApp.Mvvm.Views;

public partial class MainWindow : Window
{
    private readonly List<CustomerDto> customers = [];

    public MainWindow()
    {
        InitializeComponent();
    }

}