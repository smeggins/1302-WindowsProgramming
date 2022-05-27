using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.Reflection.ExampleImplementaion.BusinessBanking
{
    public class BusinessApp
    {
        public void Start()
        {
            var customertype = new StartupConfig().GetCustomerType();
            var customer = StartupHelper.GetObject(customertype);

        }
    }
}
