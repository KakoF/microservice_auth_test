using apiAuth.Services.Interfaces;
using System;
using apiAuth.Test.ServiceFake;
using Xunit;
using System.Threading.Tasks;
using apiAuth.Models;
using System.Net;

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
        public void Login_ShouldReturnToken_WhenSuccess()
        {
            var userAuth = new AutenticationModel();
            userAuth.Email = "kakoferrare@hotmail.com";
            userAuth.Senha = "123456";
            var okResult = _controller.Login(userAuth);
            Assert.Equal(200, (int)HttpStatusCode.OK);
        }
    }
}
