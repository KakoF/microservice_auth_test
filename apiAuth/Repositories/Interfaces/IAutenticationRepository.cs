using System.Threading.Tasks;
using apiAuth.Models;

namespace apiAuth.Repositories.Interfaces
{
  public interface IAutenticationRepository
  {
    Task<AutenticationModel> LoginAsync(AutenticationModel model);
  }
}
