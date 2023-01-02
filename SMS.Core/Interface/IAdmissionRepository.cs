using SMS.Core.Interface.Base;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Interface
{
    public interface IAdmissionRepository:IBaseRepository<Admission>
    {
        bool AllReadyExist(string studentId,int Id);
    }
}
