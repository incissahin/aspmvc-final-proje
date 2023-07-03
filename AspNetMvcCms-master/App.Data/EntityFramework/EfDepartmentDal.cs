using App.Data.Abstract;
using App.Data.Repository;
using App.Entities.Concrete;

namespace App.Data.EntityFramework
{
    public class EfDepartmentDal : GenericRepository<Department>, IDepartmentDal
    {

    }
}
