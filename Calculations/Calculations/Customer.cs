using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class Customer
    {
        public string Name => "Aref";
        public int Age => 35;

        public virtual int GetOrderByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("test");
            }
            return 100;
        }
    }

    public class LoyalCustomer : Customer
    {
        public int Discount { get; set; }

        public LoyalCustomer()
        {
            Discount = 10;
        }

        public override int GetOrderByName(string name)
        {
            return 101;
        }
    }

    public static class CustomerFactory
    {
        public static Customer CreateCustomerInstance(int orderCount)
        {
            if (orderCount <= 100)
            {
                return new Customer();
            }
            else
            {
                return new LoyalCustomer();
            }
        }
    }
}
