using System;
using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.Services.Interfaces;

namespace apiAuth.Test.ServiceFake
{
  public class AutenticationServiceFake : IAutenticationService
  {
    public async Task<AutenticationModel> Login(AutenticationModel model)
    {
      try
      {
        if(model.Email != "admin@admin.com" && model.Email != "123456"){
        throw new Exception("Nenhum usuário encontrado");
      }
        model.Token = "asdasdssdsdasdasds.asdasdasds.asdasdasd";
        return model;
      }
      catch (Exception e)
      {
        e.Data.Add("error", e.Message);
        throw e;
      }
    }
  }
}