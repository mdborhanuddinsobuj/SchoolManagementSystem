using Microsoft.AspNetCore.Http;
using SMS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.Core.Models
{
    public class AdmissionModel:BaseModel
    {
        [Required(ErrorMessage ="Pleale Enter JoiningDate")]
        public DateTime Joining { get; set; }
        [Required(ErrorMessage = "Pleale Enter StudentId")]
        public string StudentId { get; set; }
        //[Required(ErrorMessage = "Pleale Enter StudentPicture")]
        [NotMapped]
        public IFormFile StudentPic { get; set; }
        public string StudentPicture { get; set; }
        
        [Required(ErrorMessage = "Pleale Enter StudentName")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Pleale Enter StudentDOB")]
        public DateTime StudentDOB { get; set; }
        [Required(ErrorMessage = "Pleale Enter FatherName")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Pleale Enter FatherOccupation")]
        public string FatherOccupation { get; set; }
        [Required(ErrorMessage = "Pleale Enter FatherPhoneNumber")]
        public string FatherPhoneNumber { get; set; }
        [Required(ErrorMessage = "Pleale Enter MotherName")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "Pleale Enter MotherOccupation")]
        public string MotherOccupation { get; set; }
        [Required(ErrorMessage = "Pleale Enter MotherPhoneNumber")]
        public string MotherPhoneNumber { get; set; }
        [Required(ErrorMessage = "Pleale Enter StudentGender")]
        public Gender StudentGender { get; set; }
        [Required(ErrorMessage = "Pleale Enter studentAddress")]
        public string studentAddress { get; set; }
        public string StudentPhone { get; set; }
        public string MobileNumber { get; set; }
        public string NameOfLastStudying { get; set; }
        [Required(ErrorMessage = "Pleale Enter ClassName"),Display(Name ="Class")]
        [ForeignKey("classInfo")]
        public int ClassInfoId { get; set; }
        public ClassInfoModel classInfo { get; set; }
        [Required(ErrorMessage = "Pleale Enter SectionName"), Display(Name = "Section")]
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public SectionModel Section { get; set; }
        public virtual ICollection<ResultModel> Results { get; set; }
        public virtual ICollection<AdmissionFeeModel> AdmissionFees { get; set; }
        public virtual ICollection<MonthlyFeeModel> MonthlyFees { get; set; }
        public virtual ICollection<StudentTransfer> StudentTransfers { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Others
    }
}
