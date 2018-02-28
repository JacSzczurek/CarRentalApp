using System.Threading.Tasks;

namespace CarRentalApp.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}