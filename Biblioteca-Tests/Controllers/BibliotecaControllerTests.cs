using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca_backend.Controllers;
using Biblioteca_Core.Contracts;
using Biblioteca_Core.Services;
using Moq;
using Xunit;

namespace Biblioteca_Tests.Controllers
{
    public class BibliotecaControllerTests
    {
        private readonly BibliotecaController SUT;
        private readonly Mock<IBibliotecaService> iBibliotecaService;

        public BibliotecaControllerTests()
        {
            iBibliotecaService = new Mock<IBibliotecaService>();

            SUT = new BibliotecaController(iBibliotecaService.Object);
        }

        [Fact]
        public async Task GetObras()
        {
            #region Arrange

            iBibliotecaService.Setup(x => x.GetObras())
                .ReturnsAsync(() => new List<ObraResponse>()
                {
                    new ObraResponse()
                    {
                        Autores = new List<string>(){ "JK Rowling"},
                        Editora = "Rocco",
                        Foto = "https://i.imgur.com/UH3IPXw.jpg",
                        Id = 1,
                        Titulo = "Harry Potter"
                    }
                });

            #endregion

            #region Act

            var response = await SUT.GetObras();

            #endregion

            #region Assert

            Assert.Equal(1, response[0].Id);

            #endregion
        }

        [Fact]
        public async Task GetObraById()
        {
            #region Arrange

            iBibliotecaService.Setup(x => x.GetObraById(It.IsAny<int>()))
                .ReturnsAsync(() => new ObraResult()
                {
                    IsSuccess = true,
                    Data = new ObraResponse()
                    {
                        Autores = new List<string>(){ "JK Rowling"},
                        Editora = "Rocco",
                        Foto = "https://i.imgur.com/UH3IPXw.jpg",
                        Id = 1,
                        Titulo = "Harry Potter"
                    }
                });

            #endregion

            #region Act

            var response = await SUT.GetObraById(It.IsAny<int>());

            #endregion

            #region Assert

            Assert.Equal(1, response.Data.Id);

            #endregion
        }

        [Fact]
        public async Task Create()
        {
            #region Arrange

            iBibliotecaService.Setup(x => x.CreateObra(It.IsAny<ObraRequest>()))
                .ReturnsAsync(() => new ObraResult()
                {
                    IsSuccess = true,
                    Data = new ObraResponse()
                    {
                        Autores = new List<string>() { "JK Rowling" },
                        Editora = "Rocco",
                        Foto = "https://i.imgur.com/UH3IPXw.jpg",
                        Id = 1,
                        Titulo = "Harry Potter"
                    }
                });

            #endregion

            #region Act

            var response = await SUT.Create(It.IsAny<ObraRequest>());

            #endregion

            #region Assert

            Assert.Equal(1, response.Data.Id);

            #endregion
        }

        [Fact]
        public async Task Update()
        {
            #region Arrange

            iBibliotecaService.Setup(x => x.UpdateObra(It.IsAny<ObraRequest>()))
                .ReturnsAsync(() => new ObraResult()
                {
                    IsSuccess = true,
                    Data = new ObraResponse()
                    {
                        Autores = new List<string>() { "JK Rowling" },
                        Editora = "Rocco",
                        Foto = "https://i.imgur.com/UH3IPXw.jpg",
                        Id = 1,
                        Titulo = "Harry Potter"
                    }
                });

            #endregion

            #region Act

            var response = await SUT.Update(It.IsAny<int>(), It.IsAny<ObraRequest>());

            #endregion

            #region Assert

            Assert.Equal(1, response.Data.Id);

            #endregion
        }

        [Theory]
        [InlineData(true, 1)]
        public async Task Delete(bool result, int id)
        {
            #region Arrange

            iBibliotecaService.Setup(x => x.DeleteObra(It.IsAny<int>()))
                .ReturnsAsync(() => new ObraResult()
                {
                    IsSuccess = result
                });

            #endregion

            #region Act

            var response = await SUT.Delete(id);

            #endregion

            #region Assert

            Assert.Equal(result, response.IsSuccess);

            #endregion
        }
    }
}
