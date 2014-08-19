namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        { 
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        //additional tests from the homework

        [TestMethod]
        public void SortingByYearSortsAndReturnsView()
        {
            var resultModels = (List<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(1, resultModels[0].Id);
            Assert.AreEqual("Audi", resultModels[0].Make);
            Assert.AreEqual("A4", resultModels[0].Model);
            Assert.AreEqual(2005, resultModels[0].Year);

            Assert.AreEqual(3, resultModels[1].Id);
            Assert.AreEqual("BMW", resultModels[1].Make);
            Assert.AreEqual("330d", resultModels[1].Model);
            Assert.AreEqual(2007, resultModels[1].Year);

            Assert.AreEqual(2, resultModels[2].Id);
            Assert.AreEqual("BMW", resultModels[2].Make);
            Assert.AreEqual("325i", resultModels[2].Model);
            Assert.AreEqual(2008, resultModels[2].Year);

            Assert.AreEqual(4, resultModels[3].Id);
            Assert.AreEqual("Opel", resultModels[3].Make);
            Assert.AreEqual("Astra", resultModels[3].Model);
            Assert.AreEqual(2010, resultModels[3].Year);
        }

        [TestMethod]
        public void SortingByMakeSortsAndReturnsView()
        {
            var resultModels = (List<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(1, resultModels[0].Id);
            Assert.AreEqual("Audi", resultModels[0].Make);
            Assert.AreEqual("A4", resultModels[0].Model);
            Assert.AreEqual(2005, resultModels[0].Year);

            Assert.AreEqual(2, resultModels[1].Id);
            Assert.AreEqual("BMW", resultModels[1].Make);
            Assert.AreEqual("325i", resultModels[1].Model);
            Assert.AreEqual(2008, resultModels[1].Year);

            Assert.AreEqual(3, resultModels[2].Id);
            Assert.AreEqual("BMW", resultModels[2].Make);
            Assert.AreEqual("330d", resultModels[2].Model);
            Assert.AreEqual(2007, resultModels[2].Year);

            Assert.AreEqual(4, resultModels[3].Id);
            Assert.AreEqual("Opel", resultModels[3].Make);
            Assert.AreEqual("Astra", resultModels[3].Model);
            Assert.AreEqual(2010, resultModels[3].Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortByInvalidParameterShouldThrowArgumentException()
        {
            this.controller.Sort("invalidString");
        }

        [TestMethod]
        public void SearchingInvalidStringReturnsTheWholeView()
        {
            var view = (IView)this.controller.Search("invalidString");
            var resultModels = (List<Car>)view.Model;

            Assert.AreEqual(2, resultModels[0].Id);
            Assert.AreEqual("BMW", resultModels[0].Make);
            Assert.AreEqual("325i", resultModels[0].Model);
            Assert.AreEqual(2008, resultModels[0].Year);
            Assert.AreEqual(3, resultModels[1].Id);
            Assert.AreEqual("BMW", resultModels[1].Make);
            Assert.AreEqual("330d", resultModels[1].Model);
            Assert.AreEqual(2007, resultModels[1].Year);
        }

        [TestMethod]
        public void DetailsReturnsCorrectCarView()
        {
            var expectedModel = this.carsData.GetById(0);

            var viewModel = this.controller.Details(1).Model;
            Assert.AreEqual(expectedModel, viewModel);

        }

        [TestMethod]
        public void CarsControllerDetailsWorks()
        {
            var controller = new CarsController();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GettingCarShouldThrowArgumentNullExceptionIfCarIdIsNotFound()
        {
            controller.Details(-1);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
