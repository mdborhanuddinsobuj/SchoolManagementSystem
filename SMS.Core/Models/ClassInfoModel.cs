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
            //this.Admissions=new List<Admission>();
        }
        public string ClassName { get; set; }

        [ForeignKey("SectionModel")]
        public int SectionId { get; set; }
        public virtual SectionModel SectionModel { get; set; }
        public virtual ICollection<Admission> Admissions { get;set; }
    }
}
