using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.Core.Interface.Base;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Interface
{
    public interface IAdmissionFeeRepository:IBaseRepository<AdmissionFeeModel>
    {
        IEnumerable<AdmissionFeeModel> GetAll(int admissionFeeId);
        IEnumerable<SelectListItem> GetAllAdmissionFeeModelForDropDown();
    }
}
