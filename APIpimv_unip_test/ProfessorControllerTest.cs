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
    public class ProfessorControllerTest
    {
        
        [Fact]
        public async Task GetAllAsync_Professor_SizeAndTypeReturned()
        {
            // Arrange                
            var mockServ = new Mock<IProfessorService>();
            mockServ.Setup(repo => repo.ListAsync()).ReturnsAsync(GetList());

            ProfessoresController controller = new ProfessoresController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.GetAllAsync();

            // Assert
            Assert.IsType<List<ProfessorResource>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SaveAsync_Professor_OkObjectResultReturned()
        {
            // Arrange
            Professor professor = GetObject();

            SaveProfessorResource saveProfessor = new SaveProfessorResource()
            {
                Login = professor.Usuario.Login,
                IdDisciplina = professor.Disciplina.Id
            };

            var mockServ = new Mock<IProfessorService>();
            mockServ.Setup(repo => repo.SaveAsync(It.IsAny<Professor>()))
                                                            .Returns(Task.FromResult(new ProfessorResponse(It.IsAny<Professor>())))
                                                            .Verifiable();

            ProfessoresController controller = new ProfessoresController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PostAsync(saveProfessor);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ProfessorResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task UpdateAsync_Professor_OkObjectResultReturned()
        {
            // Arrange
            Professor professor = GetObject();
            professor.Usuario.Login = "humba2";

            SaveProfessorResource saveProfessor = new SaveProfessorResource()
            {
                Login = professor.Usuario.Login,
                IdDisciplina = professor.Disciplina.Id
            };

            var mockServ = new Mock<IProfessorService>();
            mockServ.Setup(repo => repo.UpdateAsync(professor.Id, It.IsAny<Professor>()))
                                                            .Returns(Task.FromResult(new ProfessorResponse(It.IsAny<Professor>())))
                                                            .Verifiable();

            ProfessoresController controller = new ProfessoresController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.PutAsync(professor.Id, saveProfessor);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ProfessorResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task DeleteAsync_Professor_OkObjectResultReturned()
        {
            // Arrange
            Professor professor = GetObject();

            SaveProfessorResource saveProfessor = new SaveProfessorResource()
            {
                Login = professor.Usuario.Login,
                IdDisciplina = professor.Disciplina.Id
            };


            var mockServ = new Mock<IProfessorService>();
            mockServ.Setup(repo => repo.DeleteAsync(professor.Id))
                                                            .Returns(Task.FromResult(new ProfessorResponse(It.IsAny<Professor>())))
                                                            .Verifiable();

            ProfessoresController controller = new ProfessoresController(mockServ.Object, AutomapperSingleton.Mapper);

            // Act
            var result = await controller.DeleteAsync(professor.Id);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ProfessorResource>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        private IEnumerable<Professor> GetList() {

            return  new List<Professor>
                    {
                        new Professor()
                        {
                            Id = 1,
                            Usuario = new Usuario
                            {
                                Login = "humba",
                                Nome = "Humberto",
                                Sobrenome = "Alves",
                                Senha = "humba123"
                            },
                            Disciplina = new Disciplina
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
                            }
                        },
                        new Professor()
                        {
                            Id = 2,
                            Usuario = new Usuario
                            {
                                Login = "doisba",
                                Nome = "Doisberto",
                                Sobrenome = "Alves",
                                Senha = "doisba123"
                            },
                            Disciplina = new Disciplina
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
                        }
                    };
        }

        private Professor GetObject()
        {
            List<Professor> pro = GetList().ToList();

            return new Professor() 
            { 
                Id = pro[0].Id, 
                Usuario = pro[0].Usuario,
                Disciplina = pro[0].Disciplina                
            };
        }
        

    }
}
