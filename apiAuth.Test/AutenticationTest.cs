using apiAuth.Services.Interfaces;
using System;
using apiAuth.Test.ServiceFake;
using Xunit;
using System.Threading.Tasks;
using apiAuth.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

namespace apiAuth.Test
{
  public class AutenticationTest
  {
    AuthController _controller;
    IAutenticationService _service;
    private readonly ITestOutputHelper _output;
    public AutenticationTest(ITestOutputHelper output)
    {
      _service = new AutenticationServiceFake();
      _controller = new AuthController(_service);
      _output = output;
    }

    [Fact]
    public async Task Login_ShouldReturnToken_WhenSuccessAsync()
    {
      var userAuth = new AutenticationModel();
      userAuth.Email = "guest@guest.com";
      userAuth.Senha = "123456";
      var response = await _controller.Login(userAuth);
      _output.WriteLine(userAuth.Email);
      _output.WriteLine(userAuth.Senha);
      //_output.WriteLine((response.Result as StatusCodeResult).StatusCode.ToString());

      Assert.Equal(200, (int)(response.Result as StatusCodeResult).StatusCode);
    }
  }
}
