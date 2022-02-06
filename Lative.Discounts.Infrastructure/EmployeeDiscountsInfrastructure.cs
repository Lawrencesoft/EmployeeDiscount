using Lative.Discounts.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lative.Discounts.Infrastructure;

namespace Lative.Discounts.Infrastructure
{
    /// <summary>
    /// This class has all the employee discount related Database methods
    /// </summary>
    public class EmployeeDiscountsInfrastructure : IEmployeeDiscountsInfrastructure
    {
        /// <summary>
        /// To get the employee details from DB.
        /// Now we don't have the DB so getting from in memory
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeeList()
        {
            return EmployeeSeedData.GetEmployeeList();
        }

        /// <summary>
        /// To get the employee discount percentage configuration
        /// </summary>
        /// <returns></returns>
        public IList<DiscountPercentage> GetDiscountPercentage()
        {
            return EmployeeSeedData.GetDiscountPercentage();
        }
    }
}
