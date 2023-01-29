using SMS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Models
{
    public class MonthlyFeeModel:BaseModel
    {
        public int AdmissionId { get; set; }
        public AdmissionModel Admission { get; set; }
        public int ClassId { get; set; }
        public ClassInfoModel ClassInfo { get; set; }
        public int sectionId { get; set; }
        public SectionModel Section { get; set; }
        public DateTime FeeDate { get; set; }
        public double AmountInTaka { get; set; }
        public string PhoneNumber { get; set; }
        public Payment Payment { get; set; }
        public string PaymentDetails { get; set; }
    }
}
