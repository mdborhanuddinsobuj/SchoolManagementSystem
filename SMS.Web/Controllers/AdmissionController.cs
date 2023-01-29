using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Core.Interface;
using SMS.Core.Models;
using System.IO;
using System;

namespace SMS.Web.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly IAdmissionRepository _admission;
        private readonly IClassInfoRepository _classInfo;
        private readonly ISectionRepository _section;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdmissionController(IAdmissionRepository admission, IClassInfoRepository classInfo, ISectionRepository section, IWebHostEnvironment webHostEnvironment)
        {
            _admission = admission;
            _classInfo = classInfo;
            _section = section;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            return View(_admission.All().Include(x=>x.classInfo).Include(x=>x.Section));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ClassInfo= _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section= _section.GetAllSectionModelForDropDown();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdmissionModel admission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_admission.AllReadyExist(admission.StudentId,admission.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    if (admission.StudentPic != null)
                    {
                        string folder = "StudentPic/";
                        folder += Guid.NewGuid().ToString() + "_" + admission.StudentPic.FileName;
                        admission.StudentPicture = "/" + folder;
                        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        admission.StudentPic.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    }
                    _admission.Insert(admission);
                }
                
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(admission);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.ClassInfo = _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section = _section.GetAllSectionModelForDropDown();
            return View(_admission.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AdmissionModel admission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (admission.StudentPic != null)
                    {
                        string folder = "StudentPic/";
                        folder += Guid.NewGuid().ToString() + "_" + admission.StudentPic.FileName;
                        admission.StudentPicture = "/" + folder;
                        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        admission.StudentPic.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    }
                    _admission.Update(admission,admission.Id);
                }
                
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(admission);
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.ClassInfo = _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section = _section.GetAllSectionModelForDropDown();
            return View(_admission.Find(id));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.ClassInfo = _classInfo.GetAllClassInfoModelForDropDown();
            ViewBag.Section = _section.GetAllSectionModelForDropDown();
            return View(_admission.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(AdmissionModel admission)
        {
            try
            {
                var adm=_admission.Find(admission.Id);
                if (adm !=null)
                {
                    _admission.Delete(adm);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(admission);
            }
        }
    }
}
