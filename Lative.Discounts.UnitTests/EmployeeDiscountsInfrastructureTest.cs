using Lative.Discounts.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Lative.Discounts.UnitTests
{
    [TestClass]
    public class EmployeeDiscountsInfrastructureTest
    {
        private readonly IEmployeeDiscountsInfrastructure _employeeDiscountsInfrastructure;
        public EmployeeDiscountsInfrastructureTest()
        {
            _employeeDiscountsInfrastructure = new EmployeeDiscountsInfrastructure();
        }

        [TestMethod]
        public void GetEmployeeList_CheckEmployeeDetailsCount_ResponseShouldMatch()
        {
            //Arrange

            //Act
            var response = _employeeDiscountsInfrastructure.GetEmployeeList();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(12, response.Count);
            Assert.AreEqual(4, response.Where(x=>x.EmployeeType == Infrastructure.Model.EmployeeType.Permanent).Count());
            Assert.AreEqual(3, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.PartTime).Count());
            Assert.AreEqual(3, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.Intern).Count());
            Assert.AreEqual(2, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.contractor).Count());
        }

        [TestMethod]
        public void GetEmployeeList_CheckPermanentEmployeeExperienceCount_ResponseShouldMatch()
        {
            //Arrange

            //Act
            var response = _employeeDiscountsInfrastructure.GetEmployeeList();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(12, response.Count);
            Assert.AreEqual(4, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.Permanent).Count());
            Assert.AreEqual(3, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.Permanent && x.EmployeeExperience >3).Count());
        }

        [TestMethod]
        public void GetDiscountPercentage_CheckPermanentEmployeePercentage_ResponseShouldMatch()
        {
            //Arrange

            //Act
            var response = _employeeDiscountsInfrastructure.GetDiscountPercentage();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(4, response.Count);
            Assert.AreEqual(10, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.Permanent).FirstOrDefault().Percentage);
            Assert.AreEqual(5, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.Permanent).FirstOrDefault().ExtraPercentage);
            Assert.AreEqual(3, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.Permanent).FirstOrDefault().CompanyExpForExtraPercentage);
            Assert.AreEqual(5, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.PartTime).FirstOrDefault().Percentage);
            Assert.AreEqual(3, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.PartTime).FirstOrDefault().ExtraPercentage);
            Assert.AreEqual(5, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.PartTime).FirstOrDefault().CompanyExpForExtraPercentage);
            Assert.AreEqual(5, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.Intern).FirstOrDefault().Percentage);
            Assert.AreEqual(30, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.Intern).FirstOrDefault().ProductPriceForDiscount);
            Assert.AreEqual(0, response.Where(x => x.EmployeeType == Infrastructure.Model.EmployeeType.contractor).FirstOrDefault().CompanyExpForExtraPercentage);
        }
    }
}
