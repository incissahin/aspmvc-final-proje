using App.Entities.Concrete;

namespace App.Data.Abstract
{
    public interface IUserDal : IGenericDal<User>
	{
		User GetUserByEmailAdress(string email);
	}
}
