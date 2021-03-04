using System;
using System.Data;
using System.Threading.Tasks;
using apiAuth.Models;

namespace apiAuth.Repositories.Interfaces
{
  public class AutenticationRepository : IAutenticationRepository
  {
    public AutenticationModel Login(AutenticationModel model)
    {
      try
      {
        return model;
      }
      catch (Exception e)
      {
        e.Data.Add("errors", new { message = "Não foi possível recuperar o usuário" });
        throw e;
      }

    }
  }
}