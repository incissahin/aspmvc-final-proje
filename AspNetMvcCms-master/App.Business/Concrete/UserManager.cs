using App.Business.Abstract;
using App.Data.Abstract;
using App.Entities.Concrete;
using System.Linq.Expressions;

namespace App.Business.Concrete
{
    public class UserManager : IUserService
	{
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task RoleUser(int id)
        {
            var user = _userDal.GetByID(id);
            if (user != null)
            {
                user.IsAdmin = true;
                _userDal.Update(user);
            }
        }

        public void TAdd(User t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public User TGetByID(int id)
        {
            return _userDal.GetByID(id);
        }

        public List<User> TGetList()
        {
            return _userDal.GetList();
        }

        public List<User> TGetListbyFilter(Expression<Func<User, bool>> filter)
        {
            return _userDal.GetByFilter(filter);
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }

        public async Task UnRoleUser(int id)
        {
            var user = _userDal.GetByID(id);
            if (user != null)
            {
                user.IsAdmin = false;
                _userDal.Update(user);
            }
        }

        public User GetUserByEmailAdress(string email)
		{
			return _userDal.GetUserByEmailAdress(email);
		}

    }
}
