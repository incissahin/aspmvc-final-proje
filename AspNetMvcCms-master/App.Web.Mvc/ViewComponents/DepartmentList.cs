using App.Business.Abstract;
using App.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.ViewComponents
{
	public class DepartmentList : ViewComponent
	{
		private readonly IDepartmentService _departmentManager;

		public DepartmentList(IDepartmentService departmentManager)
		{
			_departmentManager = departmentManager;
		}

		public IViewComponentResult Invoke()
		{
			var departments = _departmentManager.TGetList();

			return View(departments);
		}
	}
}
