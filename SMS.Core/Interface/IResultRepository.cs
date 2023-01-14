using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.Core.Interface.Base;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Interface
{
    public interface IResultRepository:IBaseRepository<ResultModel>
    {
        bool AllReadyexist(string studentId,int id);
        IEnumerable<SelectListItem> GetAllResultsForDropDown();
    }
}
