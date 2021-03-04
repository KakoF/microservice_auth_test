using System.Data;
using System.Threading.Tasks;
using apiAuth.Models;

namespace apiAuth.Repositories.Interfaces
{
  public class AutenticationRepository : IAutenticationRepository
  {
    public AutenticationModel Login(AutenticationModel model)
    {
      //throw new System.Exception("Erro em recuperar o usu�rio");
      return model;
    }
  }
}