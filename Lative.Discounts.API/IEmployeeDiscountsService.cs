namespace Lative.Discounts.API
{
    /// <summary>
    /// This Interface is used add all the Employee Discount service methods
    /// </summary>
    public interface IEmployeeDiscountsService
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
