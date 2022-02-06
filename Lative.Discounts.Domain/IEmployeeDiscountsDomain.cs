namespace Lative.Discounts.Domain
{
    /// <summary>
    /// This Interface is used add all the Employee Discount Domain methods
    /// </summary>
    public interface IEmployeeDiscountsDomain
    {
        /// <summary>
        /// Apply Discount for the specified amount depends on the employee
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public decimal? ApplyDiscount(decimal amount, int employeeId);
    }
}
