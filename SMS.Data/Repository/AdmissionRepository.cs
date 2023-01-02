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
    public class AdmissionRepository : BaseRepository<Admission>, IAdmissionRepository
    {
        private readonly PDbContext _context;
        public AdmissionRepository(PDbContext context) : base(context)
        {
            _context = context;
        }

        public bool AllReadyExist(string studentId, int Id)
        {
            if (Id > 0)
            {
                var admission = All().FirstOrDefault(x => x.studentId == studentId && Id != x.Id);
                return admission != null;
            }
            else
            {
                var admission = All().FirstOrDefault(x => x.studentId == studentId);
                return admission != null;
            }
        }
    }
}
