using System.Threading.Tasks;
using apiAuth.Models;
namespace apiAuth.Services.Interfaces
{
  public interface IAutenticationService
  {
    Task<AutenticationModel> Login(AutenticationModel model);
  }
}