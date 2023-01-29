using SMS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Core.Models
{
    public class StudentTransfer:BaseModel
    {
        public int AdmissionId { get; set; }
        public AdmissionModel Admission { get; set; }
        public int ClassInfoId { get; set; }
        public ClassInfoModel ClassInfo { get; set; }
        public int SectionId { get; set; }
        public SectionModel Section { get; set; }
        public string TransferInstitute { get; set; }
    }
}
