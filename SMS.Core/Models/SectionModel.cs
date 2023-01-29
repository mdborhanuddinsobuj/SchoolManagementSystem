using SMS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMS.Core.Models
{
    public class SectionModel:BaseModel
    {
        public SectionModel()
        {
        }
        [Required]
        public string SectionName  { get; set; }
        public virtual ICollection<AdmissionModel> Admissions { get; set; }
        public virtual ICollection<ResultModel> Results { get; set; }
        public virtual ICollection<AdmissionFeeModel> AdmissionFees { get; set; }
        public virtual ICollection<MonthlyFeeModel> MonthlyFees { get; set; }
        public virtual ICollection<StudentTransfer> StudentTransfers { get; set; }
    }
}
