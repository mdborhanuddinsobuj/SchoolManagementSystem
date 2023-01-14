using SMS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.Core.Models
{
    public class ClassInfoModel:BaseModel
    {
        public ClassInfoModel()
        {
        }
        public string ClassName { get; set; }
        public virtual ICollection<AdmissionModel> Admissions { get; set; }
        public virtual ICollection<ResultModel> Results { get; set; }
    }
}
