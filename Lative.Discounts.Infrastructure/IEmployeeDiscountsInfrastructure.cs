using Lative.Discounts.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lative.Discounts.Infrastructure
{
    /// <summary>
    /// This Interface has all the employee discount related Database methods
    /// </summary>
    public interface IEmployeeDiscountsInfrastructure
    {
        /// <summary>
        /// To get the employee details from DB.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeeList();

        /// <summary>
        /// To get the employee discount percentage configuration
        /// </summary>
        /// <returns></returns>
        public IList<DiscountPercentage> GetDiscountPercentage();
    }
}
