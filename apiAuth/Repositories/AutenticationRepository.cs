using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.Services;

namespace apiAuth.Repositories.Interfaces
{
  public class AutenticationRepository : IAutenticationRepository
  {
    private readonly IFirebaseConnection _firebasConnection;

    public AutenticationRepository(IFirebaseConnection conn)
    {
      _firebasConnection = conn;
    }
    public async Task<AutenticationModel> LoginAsync(AutenticationModel model)
    {
      try
      {
        var client = _firebasConnection.Init();
        var response = await client.GetAsync("/Usuarios");
        var users = JsonSerializer.Deserialize<List<AutenticationModel>>(response.Body.ToString());
        var auth = users.Find(e => e.Email == model.Email && e.Senha == model.Senha);
        if(auth == null){
         throw new Exception("Nenhum usuário encontrado");
        }

        return auth;
      }
      catch (Exception e)
      {
        e.Data.Add("error", e.Message);
        throw e;
      }

    }
  }
}