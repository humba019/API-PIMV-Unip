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
    public class SetorControllerTest
    {
        
        [Fact]
        public async Task GetAllAsync_Setor_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<ISetorService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            SetoresController controller = new SetoresController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<SetorResource>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SaveAsync_Setor_OkObjectResultReturned()
        {
            // Arrange
            Setor setor = GetObject();

            SaveSetorResource saveSetor = new SaveSetorResource()
            {
                Descricao = setor.Descricao
            };

            var mockServ = new Mock<ISetorService>();
            mockServ.Setup(repo => repo.SaveAsync(It.IsAny<Setor>()))
                                                            .Returns(Task.FromResult(new SaveSetorResponse(It.IsAny<Setor>())))
                                                            .Verifiable();

            SetoresController controller = new SetoresController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PostAsync(saveSetor);

            // Assert
            var actionResult = Assert.IsType<ActionResult<SetorResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task UpdateAsync_Setor_OkObjectResultReturned()
        {
            // Arrange
            Setor setor = GetObject();

            SaveSetorResource saveSetor = new SaveSetorResource()
            {
                Descricao = "Audio 2"
            };

            var mockServ = new Mock<ISetorService>();
            mockServ.Setup(repo => repo.UpdateAsync(setor.Id, It.IsAny<Setor>()))
                                                            .Returns(Task.FromResult(new SaveSetorResponse(It.IsAny<Setor>())))
                                                            .Verifiable();

            SetoresController controller = new SetoresController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PutAsync(setor.Id, saveSetor);

            // Assert
            var actionResult = Assert.IsType<ActionResult<SetorResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task DeleteAsync_Setor_OkObjectResultReturned()
        {
            // Arrange
            Setor setor = GetObject();

            SaveSetorResource saveSetor = new SaveSetorResource()
            {
                Descricao = setor.Descricao
            };


            var mockServ = new Mock<ISetorService>();
            mockServ.Setup(repo => repo.DeleteAsync(setor.Id))
                                                            .Returns(Task.FromResult(new SaveSetorResponse(It.IsAny<Setor>())))
                                                            .Verifiable();

            SetoresController controller = new SetoresController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.DeleteAsync(setor.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<SetorResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        private IEnumerable<Setor> GetList() {

            return  new List<Setor>
                    {
                        new Setor()
                        {
                            Id = 1,
                            Descricao = "Audio"
                        },
                        new Setor()
                        {
                            Id = 2,
                            Descricao = "Video"
                        }
                    };
        }

        private Setor GetObject()
        {
            List<Setor> set = GetList().ToList();

            return new Setor() 
            { 
                Id = set[0].Id, 
                Descricao = set[0].Descricao
            };
        }
        
    }
}
