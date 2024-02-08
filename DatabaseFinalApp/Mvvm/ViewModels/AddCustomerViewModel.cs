using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFinalApp.Mvvm.ViewModels
{
    public partial class AddCustomerViewModel : ObservableObject
    {
        [ObservableProperty]
        private CustomerDto _customerForm = new();


        [ObservableProperty]
        private ObservableCollection<CustomerDto> _customerList = [];

        [RelayCommand]
        public void AddCustomerToList()
        {
            if (!string.IsNullOrWhiteSpace(CustomerForm.Email) && !string.IsNullOrWhiteSpace(CustomerForm.FirstName))
            {
                CustomerList.Add(CustomerForm);
                CustomerForm = new();
            }
        }
    }
}
