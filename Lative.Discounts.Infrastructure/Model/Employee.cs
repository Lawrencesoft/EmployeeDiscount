namespace Lative.Discounts.Infrastructure.Model
{
    /// <summary>
    /// This class has the employee details
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Employee Type
        /// </summary>
        public EmployeeType EmployeeType { get; set; }

        /// <summary>
        /// Employee Years of experience
        /// </summary>
        public int EmployeeExperience { get; set; }

        /// <summary>
        /// Employee status - Active and Inactive
        /// </summary>
        public bool IsActive { get; set; }
    }
}
