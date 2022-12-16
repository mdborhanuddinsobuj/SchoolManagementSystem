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
        
    }
}
