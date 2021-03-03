using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.Services.Interfaces;
using apiAuth.utils;

namespace apiAuth.Services
{
  public class AutenticationService : IAutenticationService
  {
    public async Task<AutenticationModel> Login(AutenticationModel model)
    {
      var token = await Token.GenerateToken(model);
      model.Token = token;
      return model;
    }
  }
}