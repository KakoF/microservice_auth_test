using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.Repositories.Interfaces;
using apiAuth.Services.Interfaces;
using apiAuth.utils;

namespace apiAuth.Services
{
  public class AutenticationService : IAutenticationService
  {
    private readonly IAutenticationRepository _autenticationRepository;

    public AutenticationService(IAutenticationRepository repository)
    {
      _autenticationRepository = repository;
    }
    public async Task<AutenticationModel> Login(AutenticationModel model)
    {
      var authUser = _autenticationRepository.Login(model);
      var token = await Token.GenerateToken(model);
      authUser.Token = token;
      return authUser;
    }
  }
}