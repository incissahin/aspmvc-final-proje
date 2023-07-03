using App.Business.Abstract;
using App.Business.Concrete;
using App.Data.Concrete;
using App.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class PageController : Controller
    {
        PageManager _pageManager = new PageManager(new EfPageDal());


        [Route("page/about-us")]
        public IActionResult AboutUs()
        {
            var page = _pageManager.TGetByID(1);
            return View(page);
        }
        [Route("page/our-services")]
        public IActionResult OurServices()
        {
            var page = _pageManager.TGetByID(2);
            return View(page);
        }

        [Route("page/contact-us")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("page/make-appointment")]
        public IActionResult Appointment()
        {
            return View();
        }
    }
}
