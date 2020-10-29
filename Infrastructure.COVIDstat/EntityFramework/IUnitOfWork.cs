using System.Threading.Tasks;

namespace Infrastructure.COVIDstat.EntityFramework
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}