using SMS.Core.Interface.Base;
using SMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Interface
{
    public interface IStudentTransferRepository:IBaseRepository<StudentTransfer>
    {
        bool AlreadyExist(string trnsName, int id);
    }
}
