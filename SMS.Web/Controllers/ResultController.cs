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
        public IActionResult Create(ResultModel resultModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _result.Insert(resultModel);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(resultModel);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Admission = _admission.GetAllAdmissionForDropDown();
            ViewBag.ClassInfo = _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section = _section.GetAllSectionModelForDropDown();
            return View(_result.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ResultModel resultModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _result.Update(resultModel,resultModel.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(resultModel);
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Admission = _admission.GetAllAdmissionForDropDown();
            ViewBag.ClassInfo = _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section = _section.GetAllSectionModelForDropDown();
            return View(_result.Find(id));
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Details(ResultModel result)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _result.All();
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View(result);
        //    }
        //}
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Admission = _admission.GetAllAdmissionForDropDown();
            ViewBag.ClassInfo = _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section = _section.GetAllSectionModelForDropDown();
            return View(_result.Find(id));
        }
        [HttpPost]
        public IActionResult Delete(ResultModel result)
        {
            try
            {
                var res = _result.Find(result.Id);
                if (res!=null)
                {
                    _result.Delete(res);
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
