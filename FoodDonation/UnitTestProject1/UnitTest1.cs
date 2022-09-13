using AutoFixture;
using FoodDonation.Controllers;
using FoodDonation.Models;
using FoodDonation.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IFoodDonorRepository> _fooddonorRepoMock;
        private Fixture _fixture;
        private FoodDonorModelsController _controller;

        public EmployeeControllerTest()
        {
            _fixture = new Fixture();
            _fooddonorRepoMock = new Mock<IFoodDonorRepository>();
        }
        [TestMethod]
        public async Task Get_FoodDonorModels_Return()
        {
            var fooddonorList = _fixture.CreateMany<FoodDonorModels>(3).ToList();
            _fooddonorRepoMock.Setup(Repository => Repository.Get()).Returns(fooddonorList);

            _controller = new FoodDonorModelsController(_fooddonorRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task Get_FoodDonor_ThrowException()
        {
            _fooddonorRepoMock.Setup(repo => repo.Get()).Throws(new Exception());

            _controller = new FoodDonorModelsController(_fooddonorRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task Post_FoodDonor_ReturningOK()
        {
            var fooddonor = _fixture.Create<FoodDonorModels>();

            _fooddonorRepoMock.Setup(repo => repo.Post(It.IsAny<FoodDonorModels>())).Returns(fooddonor);
            _controller = new FoodDonorModelsController(_fooddonorRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task Put_FoodDonor_ReturnOK()
        {
            var fooddonor = _fixture.Create<FoodDonorModels>();

            _fooddonorRepoMock.Setup(repo => repo.Put(It.IsAny<FoodDonorModels>())).Returns(fooddonor);
            _controller = new FoodDonorModelsController(_fooddonorRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task Delete_Fooddonor_ReturnOK()
        {
            _fooddonorRepoMock.Setup(repo => repo.Delete(It.IsAny<int>())).Returns(true);
            _controller = new FoodDonorModelsController(_fooddonorRepoMock.Object);

            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);

        }
    }
}
