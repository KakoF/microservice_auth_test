using System;
using System.Threading.Tasks;
using apiAuth.Models;
using apiAuth.Services.Interfaces;
using apiAuth.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
  private readonly IAutenticationService _service;
  public AuthController(IAutenticationService service)
  {
    _service = service;
  }
  /// <summary>
  /// Autenticação do Usuário.
  /// </summary>
  /// <returns>A newly created TodoItem</returns>
  /// <response code="200">Retorna a Token</response>
  /// <response code="400">Caso usuário não encontrado ou inválido</response>       
  [HttpPost]
  public async Task<ActionResult<dynamic>> Login([FromBody] AutenticationModel model)
  {
    try
    {
      model.IsCustomValid();
      var userAuth = await _service.Login(model);
      return Ok(new { token = userAuth.Token });
    }
    catch (Exception e)
    {
      return BadRequest(e.Data);
    }
  }
}