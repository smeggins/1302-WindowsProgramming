using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.Reflection.ExampleImplementaion.CustomerBanking
{
    class StartupConfig
    {
        public Type GetCustomerType()
        {
            return typeof(PersonalCustomer);
        }
    }
}
