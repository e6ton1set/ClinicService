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

/*Поработать с тестированием контроллеров нашего WEB-сервиса, добавить проект с автотестами (Unit-тесты).
Добавить несколько тестов для методов добавления/удаления/редактирования объектов системы по примеру с нашего семинара.*/

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
/*            new object[] { new DateTime(2020, 1, 22), "AA1 03242422424", "Фамилия6", "Имя", "Отчество"},*/
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


        [Fact]
        public void DeleteClientTest()
        {
            // [1] Подготовка данных для тестирования
            Client testClientId = new Client();
            testClientId.ClientId = 2;

            _mockClientRepository.Setup(repository =>
            repository.Delete(It.IsNotNull<int>())).Returns(1).Verifiable();

            // [2] Исполнение тестируемого метода
            var operationResult = _clientController.Delete(testClientId.ClientId);

            // [3] Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);


            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);

            _mockClientRepository.Verify(repository =>
            repository.Delete(It.IsNotNull<int>()), Times.AtLeastOnce());
        }

    }

    public class PetControllerTests
    {

        private PetController _petController;
        private Mock<IPetRepository> _mockPetRepository;

        public PetControllerTests(){
            _mockPetRepository = new Mock<IPetRepository>();
            _petController = new PetController(_mockPetRepository.Object);
        }

        [Fact]
        public void GetAllPetsTest()
        {
            // [1] Подготовка данных для тестирования
            List<Pet> petsList = new List<Pet>();
            petsList.Add(new Pet());
            petsList.Add(new Pet());
            petsList.Add(new Pet());
            petsList.Add(new Pet());

            _mockPetRepository.Setup(repository =>
            repository.GetAll()).Returns(petsList);

            // [2] Исполнение тестируемого метода
            var operationResult = _petController.GetAll();

            // [3] Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);

            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<List<Pet>>(okObjectResult.Value);

            _mockPetRepository.Verify(repository =>
            repository.GetAll(), Times.AtLeastOnce());
        }

        public static object[][] CorrectCreatePetData =
 {
/*            new object[] { new DateTime(2000, 5, 22),  0, "Животное1"},*/
/*            new object[] { new DateTime(2000, 5, 22),  1, ""},*/
            new object[] { new DateTime(2000, 5, 22),  1, "Животное1"},
            new object[] { new DateTime(2000, 5, 22),  1, "Животное1"},
            new object[] { new DateTime(2000, 1, 22),  2, "Животное2"},
/*            new object[] { new DateTime(2000, 1, 22),  -1, "Животное3"},*/
            new object[] { new DateTime(2000, 1, 22),  2, "Животное4"},

        };

        [Theory]
        [MemberData(nameof(CorrectCreatePetData))]
        public void CreateЗуеTest
            (DateTime birthday, int clientId , string name)
        {
            // [1] Подготовка данных для тестирования
            CreatePetRequest createPetRequest = new CreatePetRequest();
            createPetRequest.Birthday = birthday;
            createPetRequest.ClientId = clientId;
            createPetRequest.Name = name;


            _mockPetRepository.Setup(repository =>
            repository.Create(It.IsNotNull<Pet>())).Returns(1).Verifiable();

            // [2] Исполнение тестируемого метода
            var operationResult = _petController.Create(createPetRequest);

            // [3] Подготовка эталонного результата и проверка результата
            Assert.IsType<OkObjectResult>(operationResult.Result);


            var okObjectResult = (OkObjectResult)operationResult.Result;
            Assert.IsAssignableFrom<int>(okObjectResult.Value);

            _mockPetRepository.Verify(repository =>
            repository.Create(It.IsNotNull<Pet>()), Times.AtLeastOnce());
        }
    }
}

