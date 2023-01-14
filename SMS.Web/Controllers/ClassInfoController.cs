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

        public ClassInfoController(IClassInfoRepository classInfo)
        {
            _classInfo = classInfo;
        }

        public IActionResult Index()
        {
            return View(_classInfo.All());
        }
        public IActionResult Create()
        {
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
            return View(_classInfo.Find(id));
        }
        
    }
}
