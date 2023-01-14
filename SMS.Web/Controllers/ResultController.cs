using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Interface;
using SMS.Core.Models;
using System.Security.AccessControl;

namespace SMS.Web.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultRepository _result;
        private readonly IAdmissionRepository _admission;
        private readonly IClassInfoRepository _classInfo;
        private readonly ISectionRepository _section;

        public ResultController(IResultRepository result, IAdmissionRepository admission, IClassInfoRepository classInfo, ISectionRepository section)
        {
            _result = result;
            _admission = admission;
            _classInfo = classInfo;
            _section = section;
        }

        public IActionResult Index()
        {
            return View(_result.All().Include(x=>x.Admission).Include(x=>x.ClassInfo).Include(x=>x.Section));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Admission = _admission.GetAllAdmissionForDropDown();
            ViewBag.ClassInfo = _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section=_section.GetAllSectionModelForDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResultModel result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_result.AllReadyexist(result.Admission.StudentId,result.Id))
                    {
                        return RedirectToAction("Index");
                    }
                    _result.Insert(result);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(result);
            }
        }
    }
}
