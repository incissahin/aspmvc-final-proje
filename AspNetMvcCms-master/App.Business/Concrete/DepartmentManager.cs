using App.Business.Abstract;
using App.Data.Abstract;
using App.Entities.Concrete;
using System.Linq.Expressions;

namespace App.Business.Concrete
{
	public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void TAdd(Department t)
        {
            _departmentDal.Insert(t);
        }

        public void TDelete(Department t)
        {
            _departmentDal.Delete(t);
        }

        public Department TGetByID(int id)
        {
            return _departmentDal.GetByID(id);
        }

        public List<Department> TGetList()
        {
            return _departmentDal.GetList();
        }

        public List<Department> TGetListbyFilter(Expression<Func<Department, bool>> filter)
        {
            return _departmentDal.GetByFilter(filter);
        }

        public void TUpdate(Department t)
        {
            _departmentDal.Update(t);
        }
    }
}
