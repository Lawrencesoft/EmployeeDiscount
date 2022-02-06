using Lative.Discounts.Domain;

namespace Lative.Discounts.API
{
    /// <summary>
    /// This calss is used add all the Employee Discount service methods
    /// </summary>
    public class EmployeeDiscountsService : IEmployeeDiscountsService
    {
        private readonly IEmployeeDiscountsDomain _employeeDicountsDomain;

        public EmployeeDiscountsService(IEmployeeDiscountsDomain employeeDicountsDomain)
        {
            _employeeDicountsDomain = employeeDicountsDomain;
        }

        /// <summary>
        /// Apply Discount for the specified amount depends on the employee
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public decimal? ApplyDiscount(decimal amount, int employeeId)
        {
            if (amount > 0)
            {
                var discountedAmount = _employeeDicountsDomain.ApplyDiscount(amount, employeeId);
                return discountedAmount;
            }
            return null;
        }
    }
}
