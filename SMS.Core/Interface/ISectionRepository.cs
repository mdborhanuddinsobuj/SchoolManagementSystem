using SMS.Core.Interface.Base;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace SMS.Core.Interface
{
    public interface ISectionRepository:IBaseRepository<SectionModel>
    {
        bool AlreadyExist(string name, int id);
        IEnumerable<SelectListItem> GetAllSectionModelForDropDown();
    }
}
