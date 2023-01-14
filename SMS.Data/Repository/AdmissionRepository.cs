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
    public class AdmissionRepository : BaseRepository<AdmissionModel>, IAdmissionRepository
    {
        private readonly PDbContext context;

        public AdmissionRepository(PDbContext context) : base(context)
        {
            this.context = context;
        }

        public bool AllReadyExist(string studentId, int admissionId)
        {
            if (admissionId>0)
            {
                var admission = All().FirstOrDefault(x => x.StudentId == studentId && admissionId != x.Id);
                return admission != null;
            }
            else
            {
                var admission = All().FirstOrDefault(x => x.StudentId == studentId);
                return admission != null;
            }
        }

        public IEnumerable<SelectListItem> GetAllAdmissionForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.StudentId,
                Value = x.Id.ToString()
            });
        }
    }
}
