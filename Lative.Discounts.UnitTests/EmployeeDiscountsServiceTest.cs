using Lative.Discounts.API;
using Lative.Discounts.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Lative.Discounts.UnitTests
{
    [TestClass]
    public class EmployeeDiscountsServiceTest
    {
        // mocked dependencies
        private readonly IEmployeeDiscountsDomain _employeeDicountsDomain;
        private readonly IEmployeeDiscountsService _employeeDiscountsService;

        public EmployeeDiscountsServiceTest()
        {
            _employeeDicountsDomain = Substitute.For<IEmployeeDiscountsDomain>();
            _employeeDiscountsService = new EmployeeDiscountsService(_employeeDicountsDomain);
        }

        [TestMethod]
        public void ApplyDiscount_ValidAmountandEmployee_ResponseShouldMatch()
        {
            //Arrange
            decimal amount = 500;
            int employeeId = 2;

            _employeeDicountsDomain.ApplyDiscount(amount, employeeId).Returns(400);

            //Act
            var response = _employeeDiscountsService.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(400, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_InvalidEmployee_ShouldNotApplyDiscount()
        {
            //Arrange
            decimal amount = 400;
            int employeeId = -1;

            _employeeDicountsDomain.ApplyDiscount(amount, employeeId).Returns(400);

            //Act
            var response = _employeeDiscountsService.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(400, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_InvalidAmount_ResponseShouldBeNull()
        {
            //Arrange
            decimal amount = -1;
            int employeeId = 2;

            _employeeDicountsDomain.ApplyDiscount(amount, employeeId).Returns(400);

            //Act
            var response = _employeeDiscountsService.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNull(response);
        }
    }
}
