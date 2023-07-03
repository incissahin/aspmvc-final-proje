using App.Business.Abstract;
using App.Data.Abstract;
using App.Data.EntityFramework;
using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
	public class PageManager : IPageService
	{
		IPageDal _pageDal;

		public PageManager(IPageDal pageDal)
		{
			_pageDal = pageDal;
		}

		public void TAdd(Page t)
		{
			_pageDal.Insert(t);
		}

		public void TDelete(Page t)
		{
			_pageDal.Delete(t);
		}

		public Page TGetByID(int id)
		{
			return _pageDal.GetByID(id);
		}

		public List<Page> TGetList()
		{
			return _pageDal.GetList();
		}

		public List<Page> TGetListbyFilter(Expression<Func<Page, bool>> filter)
		{
			return _pageDal.GetByFilter(filter);
		}

		public void TUpdate(Page t)
		{
			_pageDal.Update(t);
		}
	}
}
