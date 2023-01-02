using Microsoft.AspNetCore.Http;
using SMS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.Core.Models
{
    public class Admission:BaseModel
    {
        [Required]
        public DateTime Joining { get; set; }
        [Required]
        public string studentId { get; set; }
        [Required]
        public string studentPicture { get; set; }
        //public IFormFile studentPictureFile { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public DateTime studentDOB { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string FatherOccupation { get; set; }
        [Required]
        public string FatherPhone { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string MotherOccupation { get; set; }
        [Required]
        public string MotherPhone { get; set; }
        [Required]
        public studentGebder StudentGebder { get; set; }
        [Required]
        public string StudentAddress { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string NameOfLastStudying { get; set; }
        [Required]
        [ForeignKey("ClassInfo")]
        public int ClassInfoModelId { get; set; }
        public virtual ClassInfoModel ClassInfo { get; set; }
        [Required]
        [ForeignKey("Section")]
        public int SectionModelId { get; set; }
        public virtual SectionModel Section { get; set; }

    }
    public enum studentGebder
    {
        Male=1,
        Female=2,
        Others=3
    }
}
