using DatabaseFinalApp.Interfaces;
using DatabaseFinalApp.Mvvm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFinalApp.Services
{
    public class NavigationService : INavigationService
    {
        private readonly MainWindow _mainWindow;

        public NavigationService(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void NavigateToAddCustomer()
        {
            _mainWindow.Content = new AddCustomerView();
        }

        public void NavigateToCustomerDetails(string email)
        {
            var view = new CustomerDetailsView();
            if (view.DataContext is CustomerDetailsView vm)
            {
                vm.Email = email;
                _mainWindow.Content = view;
            }
        }
    }
}
