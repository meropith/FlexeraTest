using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repos
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();

        Task<List<T>> GetByAppID(int id);

    }
}
