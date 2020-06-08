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
    public class AulaControllerTest
    {

        [Fact]
        public async Task GetAllAsync_Aula_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<IAulaService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            AulasController controller = new AulasController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<AulaResource>>(result);
            Assert.Equal(2, result.Count());
        }
       
        [Fact]
        public async Task SaveAsync_Aula_OkObjectResultReturned()
        {
            // Arrange
            Aula aula = GetObject();

            SaveAulaResource saveAula = new SaveAulaResource()
            {
                Descricao = aula.Descricao,
                IdDisciplina = aula.IdDisciplina
            };

            var mockServ = new Mock<IAulaService>();
            mockServ.Setup(repo => repo.SaveAsync(It.IsAny<Aula>()))
                                                            .Returns(Task.FromResult(new AulaResponse(It.IsAny<Aula>())))
                                                            .Verifiable();

            AulasController controller = new AulasController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PostAsync(saveAula);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AulaResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }
        
        [Fact]
        public async Task UpdateAsync_Aula_OkObjectResultReturned()
        {
            // Arrange
            Aula aula = GetObject();

            SaveAulaResource saveAula = new SaveAulaResource()
            {
                Descricao = "Aula de Matemática 2",
                IdDisciplina = aula.Disciplina.Id
            };

            var mockServ = new Mock<IAulaService>();
            mockServ.Setup(repo => repo.UpdateAsync(aula.Id, It.IsAny<Aula>()))
                                                            .Returns(Task.FromResult(new AulaResponse(It.IsAny<Aula>())))
                                                            .Verifiable();

            AulasController controller = new AulasController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PutAsync(aula.Id, saveAula);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AulaResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task DeleteAsync_Aula_OkObjectResultReturned()
        {
            // Arrange
            Aula aula = GetObject();

            SaveAulaResource saveAula = new SaveAulaResource()
            {
                Descricao = aula.Descricao,
                IdDisciplina = aula.Disciplina.Id
            };


            var mockServ = new Mock<IAulaService>();
            mockServ.Setup(repo => repo.DeleteAsync(aula.Id))
                                                            .Returns(Task.FromResult(new AulaResponse(It.IsAny<Aula>())))
                                                            .Verifiable();

            AulasController controller = new AulasController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.DeleteAsync(aula.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<AulaResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }
        

        private IEnumerable<Aula> GetList() {

            return  new List<Aula>
                    {
                        new Aula()
                        {
                            Id = 1,
                            Andar = 2,
                            Descricao = "Aula de Matemática",
                            Disciplina = new Disciplina()
                            { 
                                Id = 1,
                                Descricao = "Matemática",
                                CargaHora = "50min",
                                Periodo = new Periodo()
                                {
                                    Id = 1,
                                    Descricao = "Diurno",
                                    HoraInicio = "07:00",
                                    HoraFim = "10:00"
                                }
                            }
                        },
                        new Aula()
                        {
                            Id = 2,
                            Andar = 1,
                            Descricao = "Aula de Historia",
                            Disciplina = new Disciplina()
                            { 
                                Id = 2, 
                                Descricao = "Historia", 
                                CargaHora = "50min", 
                                Periodo = new Periodo()
                                { 
                                    Id = 2,
                                    Descricao = "Noturno",
                                    HoraInicio = "19:00",
                                    HoraFim = "22:00"                                    
                                }
                            }
                        }
                    };
        }

        private Aula GetObject()
        {
            List<Aula> aul = GetList().ToList();

            return new Aula() 
            { 
                Id = aul[0].Id, 
                Andar = aul[0].Andar,
                Descricao = aul[0].Descricao,
                Disciplina = aul[0].Disciplina,
            };
        }

    }
}
