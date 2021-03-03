using apiAuth.Services.Interfaces;
using System;
using apiAuth.Test.ServiceFake;
using Xunit;
using System.Threading.Tasks;
using apiAuth.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace apiAuth.Test
{
  public class AutenticationTest
  {
    AuthController _controller;
    IAutenticationService _service;
    public AutenticationTest()
    {
      _service = new AutenticationServiceFake();
      _controller = new AuthController(_service);
    }

    [Fact]
    public async Task Login_ShouldReturnToken_WhenSuccessAsync()
    {
      var userAuth = new AutenticationModel();
      userAuth.Email = "guest@guest.com";
      userAuth.Senha = "123456";
      var response = await _controller.Login(userAuth);
      Assert.IsType<OkObjectResult>(response.Result);
      //Assert.Equal(200, (int)HttpStatusCode.OK);
    }
  }
}
