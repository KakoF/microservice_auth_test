using apiAuth.Models;
using apiAuth.Services.Interfaces;

namespace apiAuth.Test.ServiceFake
{
  public class AutenticationServiceFake : IAutenticationService
  {
    public AutenticationModel Login(AutenticationModel model)
    {
      return model;
    }
  }
}