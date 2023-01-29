using SMS.Core.Interface.Base;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Interface
{
    public interface IMonthlyFeeRepository:IBaseRepository<MonthlyFeeModel>
    {
        IEnumerable<MonthlyFeeModel> GetAll(int monthlyfeeId);
    }
}
