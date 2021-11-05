using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.DesignPatterns.ex2
{
    class BusinessCustomer : ICustomer
    {
        public int yearJoined { get; set; }
        public CustomerType customerType { get; set; }

        public int getLoyaltyLevel() { return 1; }
    }
}
