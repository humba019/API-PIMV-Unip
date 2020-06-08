using APIpimv_unip.Controllers;
using APIpimv_unip.Models;
using APIpimv_unip.Persistence.Repositories;
using APIpimv_unip.Resources;
using APIpimv_unip.Resources.Entity;
using APIpimv_unip.Services;
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
    public class EquipamentoControllerTest
    {
        
        [Fact]
        public async Task GetAllAsync_Equipamento_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<IEquipamentoService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            EquipamentosController controller = new EquipamentosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<EquipamentoResource>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SaveAsync_Equipamento_OkObjectResultReturned()
        {
            // Arrange
            Equipamento equipamento = GetObject();

            SaveEquipamentoResource saveEquipamento = new SaveEquipamentoResource()
            {
                Descricao = equipamento.Descricao,
                IdSetor = equipamento.Setor.Id
            };

            var mockServ = new Mock<IEquipamentoService>();
            mockServ.Setup(repo => repo.SaveAsync(It.IsAny<Equipamento>()))
                                                            .Returns(Task.FromResult(new EquipamentoResponse(It.IsAny<Equipamento>())))
                                                            .Verifiable();

            EquipamentosController controller = new EquipamentosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PostAsync(saveEquipamento);

            // Assert
            var actionResult = Assert.IsType<ActionResult<EquipamentoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task UpdateAsync_Equipamento_OkObjectResultReturned()
        {
            // Arrange
            Equipamento equipamento = GetObject();

            SaveEquipamentoResource saveEquipamento = new SaveEquipamentoResource()
            {
                Descricao = "Caixa de Som Edifier",
                IdSetor = equipamento.Setor.Id
            };

            var mockServ = new Mock<IEquipamentoService>();
            mockServ.Setup(repo => repo.UpdateAsync(equipamento.Id, It.IsAny<Equipamento>()))
                                                            .Returns(Task.FromResult(new EquipamentoResponse(It.IsAny<Equipamento>())))
                                                            .Verifiable();

            EquipamentosController controller = new EquipamentosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PutAsync(equipamento.Id, saveEquipamento);

            // Assert
            var actionResult = Assert.IsType<ActionResult<EquipamentoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task DeleteAsync_Equipamento_OkObjectResultReturned()
        {
            // Arrange
            Equipamento equipamento = GetObject();

            SaveEquipamentoResource saveEquipamento = new SaveEquipamentoResource()
            {
                Descricao = equipamento.Descricao,
                IdSetor = equipamento.Setor.Id
            };


            var mockServ = new Mock<IEquipamentoService>();
            mockServ.Setup(repo => repo.DeleteAsync(equipamento.Id))
                                                            .Returns(Task.FromResult(new EquipamentoResponse(It.IsAny<Equipamento>())))
                                                            .Verifiable();

            EquipamentosController controller = new EquipamentosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.DeleteAsync(equipamento.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<EquipamentoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        private IEnumerable<Equipamento> GetList() {

            return  new List<Equipamento>
                    {
                        new Equipamento()
                        {
                            Id = 1,
                            Descricao = "Caixa de Som",
                            Setor =  new Setor
                            {
                                Id = 1,
                                Descricao = "Audio"
                            }
                        },
                        new Equipamento()
                        {
                            Id = 2,
                            Descricao = "Projetor",
                            Setor =  new Setor
                            {
                                Id = 2,
                                Descricao = "Video"
                            }
                        }
                    };
        }

        private Equipamento GetObject()
        {
            List<Equipamento> equi = GetList().ToList();

            return new Equipamento() 
            { 
                Id = equi[0].Id, 
                Descricao = equi[0].Descricao,
                Setor = equi[0].Setor
            };
        }
        
    }
}
