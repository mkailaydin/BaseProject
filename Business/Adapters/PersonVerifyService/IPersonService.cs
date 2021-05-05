using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Adapters.PersonVerifyService
{
    public interface IPersonService
    {
        Task<bool> VerifyCid(Customer customer);
    }
}
