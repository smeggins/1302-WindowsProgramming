using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.Reflection.ExampleImplementaion.CustomerBanking
{
    class CustomerApp
    {
        public void Start()
        {
            var CustomerType = new StartupConfig().GetCustomerType();
            var CustomerObject = StartupHelper.GetObject(CustomerType);
        }
    }
}
