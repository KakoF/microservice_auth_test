using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.Services.Interfaces;

namespace apiAuth.Test.ServiceFake
{
  public class AutenticationServiceFake : IAutenticationService
  {
    public async Task<AutenticationModel> Login(AutenticationModel model)
    {
      model.Token = "asdasdssdsdasdasds.asdasdasds.asdasdasd";
      return model;
    }
  }
}