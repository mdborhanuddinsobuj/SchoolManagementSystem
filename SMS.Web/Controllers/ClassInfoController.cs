using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Interface;
using SMS.Core.Models;
using System.Linq;

namespace SMS.Web.Controllers
{
    public class ClassInfoController : Controller
    {
        private readonly IClassInfoRepository _classInfo;
        private readonly ISectionRepository _section;

        public ClassInfoController(IClassInfoRepository classInfo, ISectionRepository section)
        {
            _classInfo = classInfo;
            _section = section;
        }

        public IActionResult Index()
        {
            return View(_classInfo.All().Include(x=>x.SectionModel));
        }
        public IActionResult Create()
        {
            ViewBag.section = _section.GetAllSectionModelForDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassInfoModel classInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_classInfo.AlreadyExist(classInfo.ClassName, classInfo.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    _classInfo.Insert(classInfo);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            ViewBag.section = _section.GetAllSectionModelForDropDown();
            return View(_classInfo.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClassInfoModel classInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_classInfo.AlreadyExist(classInfo.ClassName, classInfo.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    _classInfo.Update(classInfo,classInfo.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            ViewBag.section = _section.GetAllSectionModelForDropDown();
            return View(_classInfo.Find(id));
        }
        
    }
}
