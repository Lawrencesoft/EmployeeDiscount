using Lative.Discounts.Domain;
using Lative.Discounts.Infrastructure;
using System.Collections.Generic;
using NSubstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using Lative.Discounts.Infrastructure.Model;

namespace Lative.Discounts.UnitTests
{
    [TestClass]
    public class EmployeeDiscountsDomainTest
    {
        // mocked dependencies
        private readonly IEmployeeDiscountsInfrastructure _employeeDicountsInfrastructure;

        // class being tested
        private readonly EmployeeDiscountsDomain _employeeDiscountsDomain;
        public EmployeeDiscountsDomainTest()
        {
            _employeeDicountsInfrastructure = Substitute.For<IEmployeeDiscountsInfrastructure>();
            _employeeDiscountsDomain = new EmployeeDiscountsDomain(_employeeDicountsInfrastructure);
        }

        [TestMethod]
        public void ApplyDiscount_ValidPermanentEmployee_ResponseShouldMatch()
        {
            //Arrange
            decimal amount = 400; 
            int employeeId = 2;
            IList < Employee > employeeDetail= new List<Employee>() 
            { new Employee { Id = 2, EmployeeType = EmployeeType.Permanent, EmployeeExperience = 1 } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(360, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_ValidPermanentEmployeeWithThreePlusExperience_ResponseShouldMatch()
        {
            //Arrange
            decimal amount = 400;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 2, EmployeeType = EmployeeType.Permanent, EmployeeExperience = 4 } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(340, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_ValidPartTimeEmployeeWithFivePlusExperience_ResponseShouldMatch()
        {
            //Arrange
            decimal amount = 400;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 2, EmployeeType = EmployeeType.PartTime, EmployeeExperience = 6 } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(368, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_ValidPartTimeEmployeeWithLessThanFiveYearsExperience_ResponseShouldMatch()
        {
            //Arrange
            decimal amount = 400;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 2, EmployeeType = EmployeeType.PartTime, EmployeeExperience = 4 } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(380, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_ValidInternEmployeeWithHighAmountPurchase_ResponseShouldMatch()
        {
            //Arrange
            decimal amount = 400;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 2, EmployeeType = EmployeeType.Intern } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(380, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_ValidInternEmployeeWithLessAmountPurchase_ShouldNotBeAnyDiscountAmount()
        {
            //Arrange
            decimal amount = 25;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 2, EmployeeType = EmployeeType.Intern } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(25, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_ValidcontractorEmployee_ShouldNotBeAnyDiscountAmount()
        {
            //Arrange
            decimal amount = 250;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 2, EmployeeType = EmployeeType.contractor } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(250, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_InvalidEmployee_ShouldNotBeAnyDiscountAmount()
        {
            //Arrange
            decimal amount = 600;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 3, EmployeeType = EmployeeType.contractor } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(600, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_EmptyEmployeeList_ShouldNotBeAnyDiscountAmount()
        {
            //Arrange
            decimal amount = 800;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>();

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(GetDiscountPercentage());
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(800, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_EmptyDiscountPercentageList_ShouldNotBeAnyDiscountAmount()
        {
            //Arrange
            decimal amount = 900;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 2, EmployeeType = EmployeeType.Permanent } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            IList<DiscountPercentage> discountPercentages = new List<DiscountPercentage>();
            _employeeDicountsInfrastructure.GetDiscountPercentage().Returns(discountPercentages);
            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(900, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_InvalidDiscountPercentageobject_ShouldNotBeAnyDiscountAmount()
        {
            //Arrange
            decimal amount = 1000;
            int employeeId = 2;
            IList<Employee> employeeDetail = new List<Employee>()
            { new Employee { Id = 2, EmployeeType = EmployeeType.Permanent } };

            _employeeDicountsInfrastructure.GetEmployeeList().Returns(employeeDetail);

            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1000, response.Value);
        }

        [TestMethod]
        public void ApplyDiscount_NoEmployeeNoDiscountPercentageobject_ShouldNotBeAnyDiscountAmount()
        {
            //Arrange
            decimal amount = 1000;
            int employeeId = 2;

            //Act
            var response = _employeeDiscountsDomain.ApplyDiscount(amount, employeeId);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1000, response.Value);
        }

        private IList<DiscountPercentage> GetDiscountPercentage()
        {
            IList<DiscountPercentage> discountPercentages = new List<DiscountPercentage>
            {
                new DiscountPercentage
                {
                    EmployeeType = EmployeeType.Permanent,
                    Percentage = 10,
                    ExtraPercentage = 5,
                    CompanyExpForExtraPercentage = 3
                },
                new DiscountPercentage
                {
                    EmployeeType = EmployeeType.PartTime,
                    Percentage = 5,
                    ExtraPercentage = 3,
                    CompanyExpForExtraPercentage = 5
                },
                new DiscountPercentage
                {
                    EmployeeType = EmployeeType.Intern,
                    Percentage = 5,
                    ProductPriceForDiscount = 30,
                },
                new DiscountPercentage
                {
                    EmployeeType = EmployeeType.contractor,
                    Percentage = 0,
                    ProductPriceForDiscount = 0,
                }
            };
            return discountPercentages;
        }
    }
}
