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
    public class StudentTransferRepository : BaseRepository<StudentTransfer>, IStudentTransferRepository
    {
        private readonly PDbContext _context;
        public StudentTransferRepository(PDbContext context) : base(context)
        {
            _context = context;
        }

        public bool AlreadyExist(string trnsName, int trnsId)
        {
            if (trnsId>0)
            {
                var trns = All().SingleOrDefault(x=>x.Admission.StudentId==trnsName && trnsId!=x.Id);
                return trns!= null;
            }
            else
            {
                var trns = All().SingleOrDefault(x=>x.Admission.StudentId==trnsName);
                return trns!= null;
            }
        }
    }
}
