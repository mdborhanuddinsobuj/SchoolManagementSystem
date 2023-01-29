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
    public class AdmissionFeeRepository : BaseRepository<AdmissionFeeModel>, IAdmissionFeeRepository
    {
        private readonly PDbContext context;

        public AdmissionFeeRepository(PDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<AdmissionFeeModel> GetAll(int admissionFeeId)
        {
            if (admissionFeeId == 0)
                return All();
            return All().Where(x => x.Id == admissionFeeId);
        }

        public IEnumerable<SelectListItem> GetAllAdmissionFeeModelForDropDown()
        {
            return All().Select(x=> new SelectListItem { 
            Text=x.Admission.StudentId,
            Value=x.Id.ToString()
            });
        }
    }
}
