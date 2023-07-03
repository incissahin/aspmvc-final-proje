using App.Data.Abstract;
using App.Data.Concrete;
using App.Data.Repository;
using App.Entities.Concrete;

namespace App.Data.EntityFramework
{
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        public User GetUserByEmailAdress(string email)
        {
            using var c = new AppDbContext();
            var user = c.Users.Where(u => u.Email.ToLower() == email.ToLower())?.FirstOrDefault();

            return user;
        }
    }
}
