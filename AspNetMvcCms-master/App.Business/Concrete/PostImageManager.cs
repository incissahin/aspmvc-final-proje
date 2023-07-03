using App.Business.Abstract;
using App.Data.Abstract;
using App.Entities.Concrete;
using System.Linq.Expressions;

namespace App.Business.Concrete
{
    public class PostImageManager : IPostImageService
	{
        IPostImageDal _postImageDal;

        public PostImageManager(IPostImageDal postImageDal)
        {
            _postImageDal = postImageDal;
        }

        public void TAdd(PostImage t)
        {
            _postImageDal.Insert(t);
        }

        public void TDelete(PostImage t)
        {
            _postImageDal.Delete(t);
        }

        public PostImage TGetByID(int id)
        {
            return _postImageDal.GetByID(id);
        }

        public List<PostImage> TGetList()
        {
            return _postImageDal.GetList();
        }

        public List<PostImage> TGetListbyFilter(Expression<Func<PostImage, bool>> filter)
        {
            return _postImageDal.GetByFilter(filter);
        }

        public void TUpdate(PostImage t)
        {
            _postImageDal.Update(t);
        }
    }
}
