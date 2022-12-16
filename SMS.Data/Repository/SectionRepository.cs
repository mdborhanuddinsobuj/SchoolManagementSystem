using SMS.Core.Interface;
using SMS.Core.Models;
using SMS.Core.Repository.Base;
using SMS.Data.SMSDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SMS.Data.Repository
{
    public class SectionRepository : BaseRepository<SectionModel>, ISectionRepository
    {
        private readonly PDbContext _context;
        public SectionRepository(PDbContext context) : base(context)
        {
            this._context = context;
        }

        public bool AlreadyExist(string name, int id)
        {
            if (id > 0)
            {
                var section = All().FirstOrDefault(x => x.SectionName == name && id != x.Id);
                return section != null;
            }
            else
            {
                var section = All().FirstOrDefault(x => x.SectionName == name);
                return section != null;
            }
        }

        public IEnumerable<SelectListItem> GetAllSectionModelForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SectionName.ToString(),
                Value = x.Id.ToString()
            });
        }
    }
}
