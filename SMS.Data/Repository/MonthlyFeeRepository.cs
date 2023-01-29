using SMS.Core.Interface;
using SMS.Core.Models;
using SMS.Core.Repository.Base;
using SMS.Data.SMSDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.Data.Repository
{
    public class MonthlyFeeRepository : BaseRepository<MonthlyFeeModel>, IMonthlyFeeRepository
    {
        private readonly PDbContext context;

        public MonthlyFeeRepository(PDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<MonthlyFeeModel> GetAll(int monthlyfeeId)
        {
            if (monthlyfeeId == 0)
                return All();
            return All().Where(x=>x.Id==monthlyfeeId);
        }
    }
}
