using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Calculations;

namespace TestCalculations
{
    public class CustomerTest
    {
        [Fact]
        public void CheckLegalForDiscount()
        {
            var cus = new Customer();
            Assert.InRange(cus.Age, 25, 40);
        }

        [Fact]
        public void GetOrdersByName()
        {
            var cus = new Customer();
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                cus.GetOrderByName(null);
            });
            Assert.Equal("test", ex.Message);
        }

        [Fact]
        public void LoyalCustomerForOrders100()
        {
            var cus = CustomerFactory.CreateCustomerInstance(102);
            Assert.IsType<LoyalCustomer>(cus);
        }

    }
}
