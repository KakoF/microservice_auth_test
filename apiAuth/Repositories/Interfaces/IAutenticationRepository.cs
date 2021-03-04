using System.Threading.Tasks;
using apiAuth.Models;

namespace apiAuth.Repositories.Interfaces
{
  public interface IAutenticationRepository
  {
    AutenticationModel Login(AutenticationModel model);
  }
}
