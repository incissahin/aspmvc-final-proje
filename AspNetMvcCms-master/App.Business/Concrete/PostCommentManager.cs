using App.Business.Abstract;
using App.Data.Abstract;
using App.Entities.Concrete;
using System.Linq.Expressions;

namespace App.Business.Concrete
{
    public class PostCommentManager : IPostCommentService
	{
        IPostCommentDal _postCommentDal;

        public PostCommentManager(IPostCommentDal postCommentDal)
        {
            _postCommentDal = postCommentDal;
        }

        public async Task CommentActive(int id)
        {
            var comment = _postCommentDal.GetByID(id);
            if (comment != null)
            {
                comment.IsActive = true;
                _postCommentDal.Update(comment);
            }
        }

        public void TAdd(PostComment t)
        {
            _postCommentDal.Insert(t);
        }

        public void TDelete(PostComment t)
        {
            _postCommentDal.Delete(t);
        }

        public PostComment TGetByID(int id)
        {
            return _postCommentDal.GetByID(id);
        }

        public List<PostComment> TGetList()
        {
            return _postCommentDal.GetList();
        }

        public List<PostComment> TGetListbyFilter(Expression<Func<PostComment, bool>> filter)
        {
            return _postCommentDal.GetByFilter(filter);
        }

        public void TUpdate(PostComment t)
        {
            _postCommentDal.Update(t);
        }

        public async Task Uncomment(int id)
        {
            var comment = _postCommentDal.GetByID(id);
            if (comment != null)
            {
                comment.IsActive = false;
                _postCommentDal.Update(comment);
            }
        }
    }
}
