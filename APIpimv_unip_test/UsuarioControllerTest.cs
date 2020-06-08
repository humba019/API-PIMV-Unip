using APIpimv_unip.Controllers;
using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Repositories;
using APIpimv_unip.Resources;
using APIpimv_unip.Resources.Entity;
using APIpimv_unip.Services.Communication;
using APIpimv_unip.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace APIpimv_unip_test
{
    public class UsuarioControllerTest
    {
        
        [Fact]
        public async Task GetAllAsync_Usuario_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<IUsuarioService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            UsuariosController controller = new UsuariosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<UsuarioResource>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SaveAsync_Usuario_OkObjectResultReturned()
        {
            // Arrange
            Usuario usuario = GetObject();

            SaveUsuarioResource saveUsuario = new SaveUsuarioResource()
            {
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Login = usuario.Login,
                Senha = usuario.Senha
            };

            var mockServ = new Mock<IUsuarioService>();
            mockServ.Setup(repo => repo.SaveAsync(It.IsAny<Usuario>()))
                                                            .Returns(Task.FromResult(new UsuarioResponse(It.IsAny<Usuario>())))
                                                            .Verifiable();

            UsuariosController controller = new UsuariosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PostAsync(saveUsuario);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UsuarioResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task UpdateAsync_Usuario_OkObjectResultReturned()
        {
            // Arrange
            Usuario usuario = GetObject();

            SaveUsuarioResource saveUsuario = new SaveUsuarioResource()
            {
                Nome = "Tresberto",
                Sobrenome = usuario.Sobrenome,
                Login = usuario.Login,
                Senha = usuario.Senha
            };

            var mockServ = new Mock<IUsuarioService>();
            mockServ.Setup(repo => repo.UpdateAsync(usuario.Login, It.IsAny<Usuario>()))
                                                            .Returns(Task.FromResult(new UsuarioResponse(It.IsAny<Usuario>())))
                                                            .Verifiable();

            UsuariosController controller = new UsuariosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PutAsync(usuario.Login, saveUsuario);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UsuarioResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task DeleteAsync_Usuario_OkObjectResultReturned()
        {
            // Arrange
            Usuario usuario = GetObject();

            SaveUsuarioResource saveUsuario = new SaveUsuarioResource()
            {
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                Login = usuario.Login,
                Senha = usuario.Senha
            };


            var mockServ = new Mock<IUsuarioService>();
            mockServ.Setup(repo => repo.DeleteAsync(usuario.Login))
                                                            .Returns(Task.FromResult(new UsuarioResponse(It.IsAny<Usuario>())))
                                                            .Verifiable();

            UsuariosController controller = new UsuariosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.DeleteAsync(usuario.Login);

            // Assert
            var actionResult = Assert.IsType<ActionResult<UsuarioResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        private IEnumerable<Usuario> GetList() {

            return  new List<Usuario>
                    {
                        new Usuario()
                        {
                            Nome = "Humberto",
                            Sobrenome = "Alves",
                            Cpf = "265.484.497-00",
                            Rg = "363.383.37-33",
                            Login = "humba",
                            Senha = "humba123"
                        },
                        new Usuario()
                        {
                            Nome = "Doisberto",
                            Sobrenome = "Alves",
                            Cpf = "266.484.497-00",
                            Rg = "364.383.37-33",
                            Login = "doisba",
                            Senha = "doisa123"
                        }
                    };
        }

        private Usuario GetObject()
        {
            List<Usuario> usu = GetList().ToList();

            return new Usuario() 
            { 
                Nome = usu[0].Nome,
                Sobrenome = usu[0].Sobrenome,
                Cpf = usu[0].Cpf,
                Rg = usu[0].Rg,
                Login = usu[0].Login,
                Senha = usu[0].Senha
            };
        }
        
    }
}
