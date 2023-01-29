using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Interface;

namespace SMS.Web.Controllers
{
    public class StudentTransferController : Controller
    {
        private readonly IStudentTransferRepository _transfer;
        private readonly IAdmissionRepository _admission;
        private readonly IClassInfoRepository _classInfo;
        private readonly ISectionRepository _section;

        public StudentTransferController(IStudentTransferRepository transfer, IAdmissionRepository admission, IClassInfoRepository classInfo, ISectionRepository section)
        {
            _transfer = transfer;
            _admission = admission;
            _classInfo = classInfo;
            _section = section;
        }
        public IActionResult Index()
        {
            return View(_transfer.All().Include(x=>x.Admission).Include(x=>x.ClassInfo).Include(x=>x.Section));
        }
    }
}
