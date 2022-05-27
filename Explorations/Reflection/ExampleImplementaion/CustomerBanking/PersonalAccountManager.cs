using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.Reflection.ExampleImplementaion.CustomerBanking
{
    class PersonalAccountManager : AccountManagerBase // CUSTOMER
    {
        
        public PersonalAccountManager(List<ICustomer> customers)
        {
            this.customers = customers;
        }
    }
}
