using Lative.Discounts.Infrastructure.Model;
using System.Collections.Generic;

namespace Lative.Discounts.Infrastructure
{
    /// <summary>
    /// This is Seed data class instead of database. This class can be replaced after the DB setup
    /// </summary>
    public static class EmployeeSeedData
    {
        /// <summary>
        /// This method returns all the employee details
        /// </summary>
        /// <returns></returns>
        public static IList<Employee> GetEmployeeList()
        {
            IList<Employee> Employees = new List<Employee>
        {
            new Employee{ Id = 1, Name = "Lawrence",EmployeeType = EmployeeType.Permanent,EmployeeExperience =4, IsActive= true},
            new Employee{ Id = 2, Name = "Jenisha" ,EmployeeType = EmployeeType.Permanent,EmployeeExperience =2, IsActive= true},
            new Employee{ Id = 3, Name = "Lafiya",EmployeeType = EmployeeType.Permanent,EmployeeExperience =5, IsActive= true},
            new Employee{ Id = 4, Name = "Suresh" ,EmployeeType = EmployeeType.PartTime,EmployeeExperience =2,IsActive= true},
            new Employee{ Id = 5, Name = "Micheal",EmployeeType = EmployeeType.PartTime,EmployeeExperience =3, IsActive= true},
            new Employee{ Id = 6, Name = "Russel" ,EmployeeType = EmployeeType.Intern,EmployeeExperience =7,IsActive= true},
            new Employee{ Id = 7, Name = "Sunil",EmployeeType = EmployeeType.Intern,EmployeeExperience =5, IsActive= true},
            new Employee{ Id = 8, Name = "Sayanth" ,EmployeeType = EmployeeType.Permanent,EmployeeExperience =10,IsActive= true},
            new Employee{ Id = 9, Name = "Prajan",EmployeeType = EmployeeType.contractor,EmployeeExperience =21, IsActive= true},
            new Employee{ Id = 10, Name = "Suseela" ,EmployeeType = EmployeeType.contractor,EmployeeExperience =6,IsActive= true},
            new Employee{ Id = 11, Name = "Shigna",EmployeeType = EmployeeType.PartTime,EmployeeExperience =4, IsActive= true},
            new Employee{ Id = 12, Name = "Sruthi" ,EmployeeType = EmployeeType.Intern,EmployeeExperience =12,IsActive= true},
        };
            return Employees;
        }

        /// <summary>
        /// This is employee discount configurations
        /// </summary>
        /// <returns></returns>
        public static IList<DiscountPercentage> GetDiscountPercentage()
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
