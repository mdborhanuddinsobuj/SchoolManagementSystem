using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ResultRepository : BaseRepository<ResultModel>, IResultRepository
    {
        private readonly PDbContext context;

        public ResultRepository(PDbContext context) : base(context)
        {
            this.context = context;
        }

        public bool AllReadyexist(string studentId, int id)
        {
            if (id>0)
            {
                var result = All().FirstOrDefault(x=>x.Admission.StudentId==studentId && id!=x.Id);
                return result != null;
            }
            else
            {
                var result = All().FirstOrDefault(x=>x.Admission.StudentId==studentId);
                return result != null;
            }
        }

        public IEnumerable<SelectListItem> GetAllResultsForDropDown()
        {
            return All().Select(x=> new SelectListItem
            {
                Text=x.Result,
                Value=x.Id.ToString()
            });
        }
    }
}
