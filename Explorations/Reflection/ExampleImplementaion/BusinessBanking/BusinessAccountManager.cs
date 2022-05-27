using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.Reflection.ExampleImplementaion.BusinessBanking
{
    class BusinessAccountManager : AccountManagerBase // BUISINESS
    {
        public BusinessAccountManager(List<ICustomer> customers)
        {
            this.customers = customers;
        }
    }
}
