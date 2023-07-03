using App.Business.Abstract;
using App.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly AppDbContext _context;
		public DepartmentController(IDepartmentService departmentService, AppDbContext context)
		{
			_departmentService = departmentService;
			_context = context;
		}

		public IActionResult Index()
        {
            var departments = _departmentService.TGetList();
            return View(departments);
        }

        public IActionResult Detail(int id)
        {
            var department = _context.Departments.Include(x => x.Services).FirstOrDefault(x => x.Id == id);
            return View(department);
        }
    }
}
