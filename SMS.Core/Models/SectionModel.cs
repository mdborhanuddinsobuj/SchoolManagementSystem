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
            //this.SectionModels = new List<SectionModel>();
            //this.Admissions = new List<Admission>();
        }
        [Required]
        public string SectionName  { get; set; }
        public virtual ICollection<SectionModel> SectionModels { get; set; }
        public virtual ICollection<Admission> Admissions { get; set; }
    }
}
