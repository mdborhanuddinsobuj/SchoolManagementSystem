using Microsoft.AspNetCore.Mvc;
using SMS.Core.Interface;
using SMS.Core.Models;

namespace SMS.Web.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionRepository _section;

        public SectionController(ISectionRepository section)
        {
            this._section = section;
        }
        public IActionResult Index()
        {
            return View(_section.All());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SectionModel section)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_section.AlreadyExist(section.SectionName,section.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    _section.Insert(section);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(section);
            }
        }
        public IActionResult Edit(int id)
        {
            return View(_section.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SectionModel section)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_section.AlreadyExist(section.SectionName,section.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    _section.Update(section,section.Id);
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
            return View(_section.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(SectionModel section)
        {
            try
            {
                var del = _section.Find(section.Id);
                if (del!=null)
                {
                    _section.Delete(del);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
