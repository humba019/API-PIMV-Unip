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
    public class EmprestimoControllerTest
    {
        
        [Fact]
        public async Task GetAllAsync_Emprestimo_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<IEmprestimoService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            EmprestimosController controller = new EmprestimosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<EmprestimoResource>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SaveAsync_Emprestimo_OkObjectResultReturned()
        {
            // Arrange
            Emprestimo emprestimo = GetObject();

            SaveEmprestimoResource saveEmprestimo = new SaveEmprestimoResource()
            {
                Login = emprestimo.Usuario.Login,
                IdEquipamento = emprestimo.Equipamento.Id
            };

            var mockServ = new Mock<IEmprestimoService>();
            mockServ.Setup(repo => repo.SaveAsync(It.IsAny<Emprestimo>()))
                                                            .Returns(Task.FromResult(new EmprestimoResponse(It.IsAny<Emprestimo>())))
                                                            .Verifiable();

            EmprestimosController controller = new EmprestimosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PostAsync(saveEmprestimo);

            // Assert
            var actionResult = Assert.IsType<ActionResult<EmprestimoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task UpdateAsync_Emprestimo_OkObjectResultReturned()
        {
            // Arrange
            Emprestimo emprestimo = GetObject();
            emprestimo.Usuario.Login = "tresba";
            SaveEmprestimoResource saveEmprestimo = new SaveEmprestimoResource()
            {
                Login = emprestimo.Usuario.Login,
                IdEquipamento = emprestimo.Equipamento.Id
            };

            var mockServ = new Mock<IEmprestimoService>();
            mockServ.Setup(repo => repo.UpdateAsync(emprestimo.Id, It.IsAny<Emprestimo>()))
                                                            .Returns(Task.FromResult(new EmprestimoResponse(It.IsAny<Emprestimo>())))
                                                            .Verifiable();

            EmprestimosController controller = new EmprestimosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PutAsync(emprestimo.Id, saveEmprestimo);

            // Assert
            var actionResult = Assert.IsType<ActionResult<EmprestimoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task DeleteAsync_Emprestimo_OkObjectResultReturned()
        {
            // Arrange
            Emprestimo emprestimo = GetObject();

            SaveEmprestimoResource saveEmprestimo = new SaveEmprestimoResource()
            {
                Login = emprestimo.Usuario.Login,
                IdEquipamento = emprestimo.Equipamento.Id
            };


            var mockServ = new Mock<IEmprestimoService>();
            mockServ.Setup(repo => repo.DeleteAsync(emprestimo.Id))
                                                            .Returns(Task.FromResult(new EmprestimoResponse(It.IsAny<Emprestimo>())))
                                                            .Verifiable();

            EmprestimosController controller = new EmprestimosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.DeleteAsync(emprestimo.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<EmprestimoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        private IEnumerable<Emprestimo> GetList() {

            return  new List<Emprestimo>
                    {
                        new Emprestimo()
                        {
                            Id = 1,
                            DataEmprestimo = DateTime.Now,
                            RelatorioDevolucao = "",
                            Equipamento = new Equipamento
                            {
                                Id = 1,
                                Descricao = "Caixa de Som",
                                Setor =  new Setor
                                {
                                    Id = 1,
                                    Descricao = "Audio"
                                }
                            },
                            Usuario = new Usuario
                            {
                                Nome = "Humberto",
                                Sobrenome = "Alves",
                                Login = "humba",
                                Senha = "humba123"
                            }
                        },
                        new Emprestimo()
                        {
                            Id = 2,
                            DataEmprestimo = DateTime.Now,
                            RelatorioDevolucao = "",
                            Equipamento = new Equipamento
                            {
                                Id = 2,
                                Descricao = "Projetor",
                                Setor =  new Setor
                                {
                                    Id = 2,
                                    Descricao = "Video"
                                }
                            },
                            Usuario = new Usuario
                            {
                                Nome = "Doisberto",
                                Sobrenome = "Alves",
                                Login = "doisba",
                                Senha = "doisa123"
                            }
                        }
                    };
        }

        private Emprestimo GetObject()
        {
            List<Emprestimo> emp = GetList().ToList();

            return new Emprestimo()
            {
                Id = emp[0].Id,
                Usuario = emp[0].Usuario,
                Equipamento = emp[0].Equipamento,
                RelatorioDevolucao = emp[0].RelatorioDevolucao,
                DataEmprestimo = emp[0].DataEmprestimo
            };
        }

    }
}
