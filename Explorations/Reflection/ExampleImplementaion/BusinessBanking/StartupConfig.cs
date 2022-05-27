using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.Reflection.ExampleImplementaion.BusinessBanking
{
    class StartupConfig
    {
        public Type GetCustomerType()
        {
            return typeof(BusinessCustomer);
        }
    }
}
