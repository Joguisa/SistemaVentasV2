using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS.Application.Dtos.Category.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;

namespace POS.Test.Category
{
    [TestClass]
    public class CategoryApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        // Para iniciar con nuestros métodos de prueba ,
        // antes debemos inicializarunos servicios como inyectar las clases que declaramos

        [ClassInitialize]
        public static void ClassInitialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingNullValuesOrEmpty_ShouldReturnBadRequest()
        {
            // Para hacer nuestras pruebas debemos hacer
            // una serie de eventos

            using var scope = _scopeFactory!.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();

            // Arrange
            var name = "";
            var description = "";
            var state = 1;
            var expected = ReplyMessage.MESSAGE_VALIDATE;

            // Act
            var result = await context!.RegisterCategory(new CategoryRequestDto()
            {
                Name = name,
                Description = description,
                State = state
            });
            var current = result.Message;

            // Assert
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingCorrectValues_RegisteredSuccessfully()
        {// Para hacer nuestras pruebas debemos hacer
            // una serie de eventos

            using var scope = _scopeFactory!.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();

            // Arrange
            var name = "Nuevo Registro";
            var description = "Nueva Descripción";
            var state = 1;
            var expected = ReplyMessage.MESSAGE_SAVE;

            // Act
            var result = await context!.RegisterCategory(new CategoryRequestDto()
            {
                Name = name,
                Description = description,
                State = state
            });
            var current = result.Message;

            // Assert
            Assert.AreEqual(expected, current);


        }
    }
}
