using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.Reflection.ExampleImplementaion
{
    class AccountManagerBase // BUISINESS
    {
        protected List<ICustomer> customers;

        public List<ICustomer> GetCustomer(int yearJoined, IInterestCalculator interestCalculator)
        {

            return customers;
        }
    }
}
