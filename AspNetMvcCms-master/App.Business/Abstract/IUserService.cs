using App.Data.Abstract;
using App.Entities.Concrete;

namespace App.Business.Abstract
{
    public interface IUserService : IGenericService<User>
	{
        User GetUserByEmailAdress(string email);

    }
}
