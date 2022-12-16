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
    public class ClassInfoRepository : BaseRepository<ClassInfoModel>, IClassInfoRepository
    {
        private readonly PDbContext _context;
        public ClassInfoRepository(PDbContext context) : base(context)
        {
            this._context = context;
        }

        public bool AlreadyExist(string name, int id)
        {
            if (id > 0)
            {
                var clssinfo = All().FirstOrDefault(x => x.ClassName == name && id != x.Id);
                return clssinfo != null;
            }
            else
            {
                var clssinfo = All().FirstOrDefault(x => x.ClassName == name);
                return clssinfo != null;
            }
        }
    }
}
