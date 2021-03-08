using apiAuth.Services.Interfaces;
using System;
using apiAuth.Test.ServiceFake;
using Xunit;
using System.Threading.Tasks;
using apiAuth.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

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
    [Fact]
    public async Task Login_ShouldReturnTrue_ModelStateIsValid()
    {
        // Arrange
        var expected = true;

        // Act
        var userAuth = new AutenticationModel();
        userAuth.Email = "usuario@usuario.com";
        userAuth.Senha = "123456";
        var context = new ValidationContext(userAuth, null, null);
        var results = new List<ValidationResult>();
        TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(AutenticationModel), typeof(AutenticationModel)), typeof(AutenticationModel));
        var isModelStateValid = Validator.TryValidateObject(userAuth, context, results, true);

        //var response = await _controller.Login(userAuth);
        //var actual = response.Result as BadRequestObjectResult;

        // Assert
        Assert.Equal(isModelStateValid, expected);
    }
    [Fact]
    public async Task Login_ShouldReturnStatusCode400_IfNotImprovedEmail()
    {
        // Arrange
        var expected = false;

        // Act
        var userAuth = new AutenticationModel();
        userAuth.Email = "";
        userAuth.Senha = "123456";
        var context = new ValidationContext(userAuth, null, null);
        var results = new List<ValidationResult>();
        TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(AutenticationModel), typeof(AutenticationModel)), typeof(AutenticationModel));
        var isModelStateValid = Validator.TryValidateObject(userAuth, context, results, true);

        //var response = await _controller.Login(userAuth);
        //var actual = response.Result as BadRequestObjectResult;

        // Assert
        Assert.Equal(isModelStateValid, expected);
    }
    [Fact]
    public async Task Login_ShouldReturnStatusCode400_IfImprovedEmailIsNotValid()
    {
        // Arrange
        var expected = false;

        // Act
        var userAuth = new AutenticationModel();
        userAuth.Email = "usuario.usuario";
        userAuth.Senha = "123456";
        var context = new ValidationContext(userAuth, null, null);
        var results = new List<ValidationResult>();
        TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(AutenticationModel), typeof(AutenticationModel)), typeof(AutenticationModel));
        var isModelStateValid = Validator.TryValidateObject(userAuth, context, results, true);

        //var response = await _controller.Login(userAuth);
        //var actual = response.Result as BadRequestObjectResult;

        // Assert
        Assert.Equal(isModelStateValid, expected);
    }

    [Fact]
    public async Task Login_ShouldReturnStatusCode400_IfNotImprovedSenha()
    {
        // Arrange
        var expected = false;

        // Act
        var userAuth = new AutenticationModel();
        userAuth.Email = "usuario@usuario.com";
        userAuth.Senha = "";
        var context = new ValidationContext(userAuth, null, null);
        var results = new List<ValidationResult>();
        TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(AutenticationModel), typeof(AutenticationModel)), typeof(AutenticationModel));
        var isModelStateValid = Validator.TryValidateObject(userAuth, context, results, true);

        //var response = await _controller.Login(userAuth);
        //var actual = response.Result as BadRequestObjectResult;

        // Assert
        Assert.Equal(isModelStateValid, expected);
    }
    [Fact]
    public async Task Login_ShouldReturnStatusCode400_IfNotSenhaNotValid()
    {
        // Arrange
        var expected = false;

        // Act
        var userAuth = new AutenticationModel();
        userAuth.Email = "usuario@usuario.com";
        userAuth.Senha = "123";
        var context = new ValidationContext(userAuth, null, null);
        var results = new List<ValidationResult>();
        TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(AutenticationModel), typeof(AutenticationModel)), typeof(AutenticationModel));
        var isModelStateValid = Validator.TryValidateObject(userAuth, context, results, true);

        //var response = await _controller.Login(userAuth);
        //var actual = response.Result as BadRequestObjectResult;

        // Assert
        Assert.Equal(isModelStateValid, expected);
    }

    }
}
