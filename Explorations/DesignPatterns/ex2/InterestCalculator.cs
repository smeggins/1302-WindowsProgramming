using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.DesignPatterns.ex2
{
    public interface IInterestCalculator
    {
        public float calculateInterestRate() { return -1; }
    }

    public class PersonalInterestCalculator : IInterestCalculator 
    {
        public float calculateInterestRate(ICustomer customer)
        {
            int loyaltyLevel = customer.getLoyaltyLevel();
            if (customer.yearJoined < 2012 && loyaltyLevel > 3)
            {
                return 1.25f;
            }
            else if (customer.yearJoined > 2012 && loyaltyLevel > 3)
            {
                return 0.75f;
            }

            return .5f;
        }
    }

    public class BusinessInterestCalculator : IInterestCalculator
    {
        public float calculateBusinessInterestRate(ICustomer customer)
        {
            int loyaltyLevel;
            if (customer.customerType == CustomerType.Personal)
            {
                loyaltyLevel = customer.getLoyaltyLevel();
                if (customer.yearJoined < 2012 && loyaltyLevel > 3)
                {
                    return 1.5f;
                }
                else if (customer.yearJoined > 2012 && loyaltyLevel > 3)
                {
                    return 0.75f;
                }
            }
            return .5f;
        }
    }
}
