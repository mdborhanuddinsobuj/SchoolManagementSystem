using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Interface;
using SMS.Core.Models;

namespace SMS.Web.Controllers
{
    public class MonthlyFeeController : Controller
    {
        public readonly IMonthlyFeeRepository _monthlyFee;
        private readonly IClassInfoRepository _classInfo;
        private readonly ISectionRepository _section;
        private readonly IAdmissionRepository _admission;
        public MonthlyFeeController(IMonthlyFeeRepository monthlyFee, IClassInfoRepository classInfo, ISectionRepository section, IAdmissionRepository admission)
        {
            _monthlyFee = monthlyFee;
            _classInfo = classInfo;
            _section = section;
            _admission = admission;
        }

        public IActionResult Index()
        {
            return View(_monthlyFee.All().Include(x=>x.ClassInfo).Include(x=>x.Section).Include(x=>x.Admission));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ClassInfo = _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section = _section.GetAllSectionModelForDropDown();
            ViewBag.Admission = _admission.GetAllAdmissionForDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MonthlyFeeModel monthlyFee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _monthlyFee.Insert(monthlyFee);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(monthlyFee);
            }
        }
    }
}
