using System;
using System.Linq;
using Lative.Discounts.Infrastructure;

namespace Lative.Discounts.Domain
{
    /// <summary>
    /// This class helps to handle all the bussiness logic of employee discount
    /// </summary>
    public class EmployeeDiscountsDomain : IEmployeeDiscountsDomain
    {
        private readonly IEmployeeDiscountsInfrastructure _employeeDicountsInfrastructure;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeeDiscountsInfrastructure"></param>
        public EmployeeDiscountsDomain(IEmployeeDiscountsInfrastructure employeeDiscountsInfrastructure)
        {
            _employeeDicountsInfrastructure = employeeDiscountsInfrastructure;
        }

        /// <summary>
        /// Apply Discount for the specified amount depends on the employee type
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public decimal? ApplyDiscount(decimal amount, int employeeId)
        {
            decimal discountAmount = amount;
            try
            {
                var employee = _employeeDicountsInfrastructure.GetEmployeeList().FirstOrDefault(x => x.Id == employeeId);
                if (employee != null)
                {
                    var discountPercentageDetail = _employeeDicountsInfrastructure.GetDiscountPercentage().FirstOrDefault(x => x.EmployeeType == employee.EmployeeType);
                    if (discountPercentageDetail != null)
                    {
                        if (discountPercentageDetail.EmployeeType == Infrastructure.Model.EmployeeType.Permanent && employee.EmployeeExperience > discountPercentageDetail.CompanyExpForExtraPercentage)
                        {
                            discountAmount = amount - (amount * (discountPercentageDetail.Percentage + discountPercentageDetail.ExtraPercentage) / 100);
                        }
                        else if (discountPercentageDetail.EmployeeType == Infrastructure.Model.EmployeeType.Permanent)
                        {
                            discountAmount = amount - (amount * discountPercentageDetail.Percentage / 100);
                        }
                        else if (discountPercentageDetail.EmployeeType == Infrastructure.Model.EmployeeType.PartTime && employee.EmployeeExperience > discountPercentageDetail.CompanyExpForExtraPercentage)
                        {
                            discountAmount = amount - (amount * (discountPercentageDetail.Percentage + discountPercentageDetail.ExtraPercentage) / 100);
                        }
                        else if (discountPercentageDetail.EmployeeType == Infrastructure.Model.EmployeeType.PartTime)
                        {
                            discountAmount = amount - (amount * discountPercentageDetail.Percentage / 100);
                        }
                        else if (discountPercentageDetail.EmployeeType == Infrastructure.Model.EmployeeType.Intern && amount > discountPercentageDetail.ProductPriceForDiscount)
                        {
                            discountAmount = amount - (amount * discountPercentageDetail.Percentage / 100);
                        }
                    }
                }
                return discountAmount;
            }
            catch (Exception)
            {
                //Log the exception
                return null;
            }
        }
    }
}
