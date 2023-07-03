using App.Business.Abstract;
using App.Data.Abstract;
using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
	public class CategoryPostManager : ICategoryPostService
	{
		ICategoryPostDal _categoryPostDal;

		public CategoryPostManager(ICategoryPostDal categoryPostDal)
		{
			_categoryPostDal = categoryPostDal;
		}

		public void TAdd(CategoryPost t)
		{
			_categoryPostDal.Insert(t);
		}

		public void TDelete(CategoryPost t)
		{
			_categoryPostDal.Delete(t);
		}

		public CategoryPost TGetByID(int id)
		{
			return _categoryPostDal.GetByID(id);
		}

		public List<CategoryPost> TGetList()
		{
			return _categoryPostDal.GetList();
		}

		public List<CategoryPost> TGetListbyFilter(Expression<Func<CategoryPost, bool>> filter)
		{
			return _categoryPostDal.GetByFilter(filter);
		}

		public void TUpdate(CategoryPost t)
		{
			_categoryPostDal.Update(t);
		}
	}
}
