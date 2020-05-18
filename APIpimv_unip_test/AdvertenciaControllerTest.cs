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
    public class AdvertenciaControllerTest
    {

        [Fact]
        public async Task GetAllAsync_Advertencia_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<IAdvertenciaService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            AdvertenciasController controller = new AdvertenciasController(mockServ.Object, AutomapperSingletonModelToResource.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<AdvertenciaResource>>(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task SaveAsync_Advertencia_SizeAndTypeReturned()
        {
            // Arrange
            int id = 3;
            string descricao = "GRAVE";
            int nivel = 3;

            SaveAdvertenciaResource advertencia = new SaveAdvertenciaResource()
            {
                Descricao = descricao,
                Nivel = nivel
            };

            var mockServ = new Mock<IAdvertenciaService>();
            mockServ.Setup(repo => repo.SaveAsync(new Advertencia()
            {
                Id = id,
                Descricao = advertencia.Descricao,
                Nivel = advertencia.Nivel
            })).ReturnsAsync(new AdvertenciaResponse(new Advertencia()
            {
                Id = id,
                Descricao = advertencia.Descricao,
                Nivel = advertencia.Nivel
            }));

            AdvertenciasController controller = new AdvertenciasController(mockServ.Object, AutomapperSingletonResourceToModel.Mapper);

            // Act
            var result = await controller.PostAsync(advertencia);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
  

        private IEnumerable<Advertencia> GetList() {

            return  new List<Advertencia>
                    {
                        new Advertencia()
                        {
                            Id = 1,
                            Descricao = "LEVE",
                            Nivel = 1
                        },
                        new Advertencia()
                        {
                            Id = 2,
                            Descricao = "MEDIA",
                            Nivel = 2
                        }
                    };
        }

    }
}
