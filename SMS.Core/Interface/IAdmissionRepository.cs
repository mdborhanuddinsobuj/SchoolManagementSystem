﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.Core.Interface.Base;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Interface
{
    public interface IAdmissionRepository:IBaseRepository<AdmissionModel>
    {
        bool AllReadyExist(string studentId, int admissionId);
        IEnumerable<SelectListItem> GetAllAdmissionForDropDown();
    }
}
