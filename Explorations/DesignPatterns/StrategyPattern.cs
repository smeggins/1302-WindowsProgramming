using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.DesignPatterns
{
    public enum customerType
    {
        Personal,
        Elite,
        Business,
        BusinessElite
    }
    public class Customer
    {
        public int yearJoined;
        public customerType type;
    }

    public class Account
    {
        private IInterestCalculator interestCalculator;
        public void interestRate(IInterestCalculator interestCalculator)
        {
            this.interestCalculator = interestCalculator;
        }
        public float interestRate(Customer customer)
        {
            return interestCalculator.calculateInterest(customer);
        }
    }

    public interface IInterestCalculator
    {
        public float calculateInterest(Customer customer);
    }
    
}
