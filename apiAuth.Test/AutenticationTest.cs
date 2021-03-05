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
    public async Task Login_ShouldReturnStatusCode200()
    {
      // Arrange
      var expected = new OkObjectResult(value: new {
        token = "asdasdssdsdasdasds.asdasdasds.asdasdasd"
      });

      // Act
      var userAuth = new AutenticationModel();
      userAuth.Email = "guest@guest.com";
      userAuth.Senha = "123456";
      var response = await _controller.Login(userAuth);
      var actual = response.Result as OkObjectResult;
      
      // Assert
      Assert.Equal(actual.StatusCode, expected.StatusCode);
    }
  }
}
