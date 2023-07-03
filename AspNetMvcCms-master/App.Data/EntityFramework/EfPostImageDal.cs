using App.Data.Abstract;
using App.Entities.Concrete;
using App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.EntityFramework
{
	public class EfPostImageDal : GenericRepository<PostImage>,IPostImageDal
	{
	}
}
