using ClinicService.Controllers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicServiceTests
{
    public class ClientControllerTests
    {

        private ClientController _clientController;
        private Mock<IClientRepository> _mockClientRepository;

        public ClientControllerTests() {
            _mockClientRepository = new Mock<IClientRepository>();
            _clientController = new ClientController(_mockClientRepository.Object);
        }

        [Fact]
        public void GetAllClientsTest()
        {
            // [1] Подготовка данных для тестирования
            List<Client> clientsList = new List<Client>();
            clientsList.Add(new Client());
            clientsList.Add(new Client());
            clientsList.Add(new Client());

            _mockClientRepository.Setup(repository =>
            repository.GetAll()).Returns(clientsList);

            // [2] Исполнение тестируемого метода
            var operationResult = _clientController.GetAll();

            // [3] Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);

            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<List<Client>>(okObjectResult.Value);

            _mockClientRepository.Verify(repository =>
            repository.GetAll(), Times.AtLeastOnce());
        }

        /*[Fact]*/
        /*       public void CreateClientTest()
               {
                   // [1] Подготовка данных для тестирования
                   var createClientRequest = new CreateClientRequest();
                   createClientRequest.Document = "AA1 00300399439";
                   createClientRequest.FirstName = "Иванов";
                   createClientRequest.SurName = "Павел";
                   createClientRequest.Patronymic = "Николаевич";
                   createClientRequest.Birthday = DateTime.Now.AddYears(-33);

                   _mockClientRepository.Setup(repository =>
                   repository.Create(It.IsNotNull<Client>())).Returns(1).Verifiable();

                   // [2] Исполнение тестируемого метода
                   var operationResult = _clientController.Create(createClientRequest);

                   // [3] Подготовка эталонного результата и проверка результата
                   Assert.IsType<OkObjectResult>(operationResult.Result);


                   var okObjectResult = (OkObjectResult)operationResult.Result;
                   Assert.IsAssignableFrom<int>(okObjectResult.Value);

                   _mockClientRepository.Verify(repository =>
                   repository.Create(It.IsNotNull<Client>()), Times.AtLeastOnce());
               }*/

        public static object[][] CorrectCreateClientData =
        {
            new object[] { new DateTime(1986, 1, 22), "AA1 03242422424", "Фамилия1", "Имя", "Отчество"},
            new object[] { new DateTime(1986, 1, 22), "AA1 03242422424", "Фамилия2", "Имя", "Отчество"},
            new object[] { new DateTime(1986, 1, 22), "AA1 03242422424", "Фамилия3", "Имя", "Отчество"},
            new object[] { new DateTime(1986, 1, 22), "AA1 03242422424", "Фамилия4", "Имя", "Отчество"},
            new object[] { new DateTime(1986, 1, 22), "AA1 03242422424", "Фамилия5", "Имя", "Отчество"},
            new object[] { new DateTime(1500, 1, 22), "AA1 03242422424", "Фамилия6", "Имя", "Отчество"},
        };

        [Theory]
        [MemberData(nameof(CorrectCreateClientData))]
        public void CreateClientTest
            (DateTime birthday, string document, string surName, string firstName, string patronymic)
        {
            // [1] Подготовка данных для тестирования
            CreateClientRequest createClientRequest = new CreateClientRequest();
            createClientRequest.Birthday = birthday;
            createClientRequest.Document = document;
            createClientRequest.SurName = surName;
            createClientRequest.FirstName = firstName;
            createClientRequest.Patronymic = patronymic;


            _mockClientRepository.Setup(repository =>
            repository.Create(It.IsNotNull<Client>())).Returns(1).Verifiable();

            // [2] Исполнение тестируемого метода
            var operationResult = _clientController.Create(createClientRequest);

            // [3] Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);


            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);

            _mockClientRepository.Verify(repository =>
            repository.Create(It.IsNotNull<Client>()), Times.AtLeastOnce());
        }
    }
}
