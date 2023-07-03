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
	public class PostManager : IPostService
	{
		IPostDal _postDal;

		public PostManager(IPostDal postDal)
		{
			_postDal = postDal;
		}

		public void TAdd(Post t)
		{
			_postDal.Insert(t);
		}

		public void TDelete(Post t)
		{
			_postDal.Delete(t);
		}

		public Post TGetByID(int id)
		{
			return _postDal.GetByID(id);	
		}

		public List<Post> TGetList()
		{
			return _postDal.GetList();
		}

		public List<Post> TGetListbyFilter(Expression<Func<Post, bool>> filter)
		{
			return _postDal.GetByFilter(filter);
		}

		public void TUpdate(Post t)
		{
			_postDal.Update(t);
		}
	}
}
