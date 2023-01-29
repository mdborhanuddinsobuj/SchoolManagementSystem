using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Interface;
using SMS.Core.Models;

namespace SMS.Web.Controllers
{
    public class AdmissionFeeController : Controller
    {
        private readonly IAdmissionFeeRepository _admissionFee;
        private readonly IClassInfoRepository _classInfo;
        private readonly ISectionRepository _section;
        private readonly IAdmissionRepository _admission;

        public AdmissionFeeController(IAdmissionFeeRepository admissionFee, IClassInfoRepository classInfo, ISectionRepository section, IAdmissionRepository admission)
        {
            _admissionFee = admissionFee;
            _classInfo = classInfo;
            _section = section;
            this._admission = admission;
        }

        public IActionResult Index()
        {
            return View(_admissionFee.All().Include(x=>x.ClassInfo).Include(x=>x.Section).Include(x=>x.Admission));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ClassInfo=_classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section=_section.GetAllSectionModelForDropDown();
            ViewBag.Admission=_admission.GetAllAdmissionForDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdmissionFeeModel admissionFee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _admissionFee.Insert(admissionFee);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(admissionFee);
            }
        }
    }
}
