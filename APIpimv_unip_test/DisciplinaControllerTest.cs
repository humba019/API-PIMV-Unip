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
    public class DisciplinaControllerTest
    {
        

        [Fact]
        public async Task GetAllAsync_Disciplina_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<IDisciplinaService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            DisciplinasController controller = new DisciplinasController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<DisciplinaResource>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SaveAsync_Disciplina_OkObjectResultReturned()
        {
            // Arrange
            Disciplina disciplina = GetObject();

            SaveDisciplinaResource saveDisciplina = new SaveDisciplinaResource()
            {
                Descricao = disciplina.Descricao,
                CargaHora = disciplina.CargaHora,
                IdPeriodo = disciplina.Periodo.Id
            };

            var mockServ = new Mock<IDisciplinaService>();
            mockServ.Setup(repo => repo.SaveAsync(It.IsAny<Disciplina>()))
                                                            .Returns(Task.FromResult(new DisciplinaResponse(It.IsAny<Disciplina>())))
                                                            .Verifiable();

            DisciplinasController controller = new DisciplinasController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PostAsync(saveDisciplina);

            // Assert
            var actionResult = Assert.IsType<ActionResult<DisciplinaResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task UpdateAsync_Disciplina_OkObjectResultReturned()
        {
            // Arrange
            Disciplina disciplina = GetObject();

            SaveDisciplinaResource saveDisciplina = new SaveDisciplinaResource()
            {
                Descricao = "Matemática 2",
                CargaHora = disciplina.CargaHora,
                IdPeriodo = disciplina.Periodo.Id
            };

            var mockServ = new Mock<IDisciplinaService>();
            mockServ.Setup(repo => repo.UpdateAsync(disciplina.Id, It.IsAny<Disciplina>()))
                                                            .Returns(Task.FromResult(new DisciplinaResponse(It.IsAny<Disciplina>())))
                                                            .Verifiable();

            DisciplinasController controller = new DisciplinasController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PutAsync(disciplina.Id, saveDisciplina);

            // Assert
            var actionResult = Assert.IsType<ActionResult<DisciplinaResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task DeleteAsync_Disciplina_OkObjectResultReturned()
        {
            // Arrange
            Disciplina disciplina = GetObject();

            SaveDisciplinaResource saveDisciplina = new SaveDisciplinaResource()
            {
                Descricao = disciplina.Descricao,
                CargaHora = disciplina.CargaHora,
                IdPeriodo = disciplina.Periodo.Id
            };


            var mockServ = new Mock<IDisciplinaService>();
            mockServ.Setup(repo => repo.DeleteAsync(disciplina.Id))
                                                            .Returns(Task.FromResult(new DisciplinaResponse(It.IsAny<Disciplina>())))
                                                            .Verifiable();

            DisciplinasController controller = new DisciplinasController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.DeleteAsync(disciplina.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<DisciplinaResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        private IEnumerable<Disciplina> GetList() {

            return  new List<Disciplina>
                    {
                        new Disciplina()
                        {
                            Id = 1,
                            Descricao = "Matematica",
                            AreaAcademica = "Ciencias Exatas",                         
                            CargaHora = "50min",
                            Periodo = new Periodo()
                            {
                                Id = 1,
                                Descricao = "Diurno",
                                HoraInicio = "07:00",
                                HoraFim = "10:00"
                            }        
                        },
                        new Disciplina()
                        {
                            Id = 2,
                            Descricao = "Historia",
                            AreaAcademica = "Ciencias Humanas",
                            CargaHora = "50min",
                            Periodo = new Periodo()
                            {
                                Id = 2,
                                Descricao = "Noturno",
                                HoraInicio = "19:00",
                                HoraFim = "22:00"
                            }                            
                        }
                    };
        }

        private Disciplina GetObject()
        {
            List<Disciplina> dis = GetList().ToList();

            return new Disciplina() 
            { 
                Id = dis[0].Id, 
                Descricao = dis[0].Descricao, 
                CargaHora = dis[0].CargaHora,
                AreaAcademica = dis[0].AreaAcademica,
                Periodo = dis[0].Periodo
            };
        }
    }
}
