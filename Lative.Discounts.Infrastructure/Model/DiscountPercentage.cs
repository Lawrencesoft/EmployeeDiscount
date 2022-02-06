namespace Lative.Discounts.Infrastructure.Model
{
    /// <summary>
    /// This Class holds the employee discount percentages
    /// </summary>
    public class DiscountPercentage
    {
        /// <summary>
        /// Enployee Type  Permanent, PartTime, Interns and Contractor
        /// </summary>
        public EmployeeType EmployeeType { get; set; }

        /// <summary>
        /// Employee discount percentage
        /// </summary>
        public int Percentage { get; set; }

        /// <summary>
        /// Additional discount percentage depends on years of experience
        /// </summary>
        public int ExtraPercentage { get; set; }

        /// <summary>
        /// Additional discount eligible years of experience in the company
        /// </summary>
        public int CompanyExpForExtraPercentage { get; set; }

        /// <summary>
        /// Discount eligible for the specified Product Price
        /// </summary>
        public int ProductPriceForDiscount { get; set; }
    }
}
