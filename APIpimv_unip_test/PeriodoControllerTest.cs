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
    public class PeriodoControllerTest
    {
        
        [Fact]
        public async Task GetAllAsync_Periodo_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<IPeriodoService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            PeriodosController controller = new PeriodosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<PeriodoResource>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SaveAsync_Periodo_OkObjectResultReturned()
        {
            // Arrange
            Periodo periodo = GetObject();

            SavePeriodoResource savePeriodo = new SavePeriodoResource()
            {
                Descricao = periodo.Descricao,
                HoraInicio = periodo.HoraInicio,
                HoraFim = periodo.HoraFim
            };

            var mockServ = new Mock<IPeriodoService>();
            mockServ.Setup(repo => repo.SaveAsync(It.IsAny<Periodo>()))
                                                            .Returns(Task.FromResult(new PeriodoResponse(It.IsAny<Periodo>())))
                                                            .Verifiable();

            PeriodosController controller = new PeriodosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PostAsync(savePeriodo);

            // Assert
            var actionResult = Assert.IsType<ActionResult<PeriodoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task UpdateAsync_Periodo_OkObjectResultReturned()
        {
            // Arrange
            Periodo periodo = GetObject();

            SavePeriodoResource savePeriodo = new SavePeriodoResource()
            {
                Descricao = "Diurno 2",
                HoraInicio = periodo.HoraInicio,
                HoraFim = periodo.HoraFim
            };

            var mockServ = new Mock<IPeriodoService>();
            mockServ.Setup(repo => repo.UpdateAsync(periodo.Id, It.IsAny<Periodo>()))
                                                            .Returns(Task.FromResult(new PeriodoResponse(It.IsAny<Periodo>())))
                                                            .Verifiable();

            PeriodosController controller = new PeriodosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PutAsync(periodo.Id, savePeriodo);

            // Assert
            var actionResult = Assert.IsType<ActionResult<PeriodoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task DeleteAsync_Periodo_OkObjectResultReturned()
        {
            // Arrange
            Periodo periodo = GetObject();

            SavePeriodoResource savePeriodo = new SavePeriodoResource()
            {
                Descricao = periodo.Descricao,
                HoraInicio = periodo.HoraInicio,
                HoraFim = periodo.HoraFim
            };


            var mockServ = new Mock<IPeriodoService>();
            mockServ.Setup(repo => repo.DeleteAsync(periodo.Id))
                                                            .Returns(Task.FromResult(new PeriodoResponse(It.IsAny<Periodo>())))
                                                            .Verifiable();

            PeriodosController controller = new PeriodosController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.DeleteAsync(periodo.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<PeriodoResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        private IEnumerable<Periodo> GetList() {

            return  new List<Periodo>
                    {
                        new Periodo()
                        {
                            Id = 1,
                            Descricao = "Diurno",
                            HoraInicio = "07:00",
                            HoraFim = "10:00"
                        },
                        new Periodo()
                        {
                            Id = 2,
                            Descricao = "Noturno",
                            HoraInicio = "19:00",
                            HoraFim = "22:00"
                        }
                    };
        }

        private Periodo GetObject()
        {
            List<Periodo> per = GetList().ToList();

            return new Periodo() 
            { 
                Id = per[0].Id,
                Descricao = per[0].Descricao, 
                HoraInicio = per[0].HoraInicio,
                HoraFim = per[0].HoraFim             
            };
        }
        

    }
}
