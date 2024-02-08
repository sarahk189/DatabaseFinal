using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFinalApp.Interfaces
{
    public interface INavigationService
    {
        void NavigateToAddCustomer();
        void NavigateToCustomerDetails(string email);
    }

}
