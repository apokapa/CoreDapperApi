using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using CoreDapperApi.Repositories;
using CoreDapperApi.Models;
using CoreDapperApi.Data;
using Microsoft.Extensions.Configuration;

namespace ApiUnitTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    [TestClass]
    public class CmUserRepositoryTest
    {
        private IcustomersRepository CreateRepository()
        {
            return new customersRepository(@"Server=yourServer,yourPort;Database=yourDatabase;MultipleActiveResultSets=true;User ID=yourUser;Password=yourPassword;");

        }

        [TestMethod]
        public void GetAll()
        {
            // arrange
            IcustomersRepository repository = CreateRepository();

            // act
            var cmusers = repository.GetAllCustomers();

            // assert
            cmusers.Should().NotBeNull();
        }

        //Vat,Email,FirstName,LastName
        static int id;
        [TestMethod]
        public void Insert()
        {
            // arrange
            IcustomersRepository repository = CreateRepository();
            var CustomersModel = new customersModel
            {
                Vat = "213456777",
                Email = "joedoe22@gmail.com",
                FirstName = "TestFirstName",
                LastName = "TestLastName"
            };

            // act
            repository.InsertCustomer(CustomersModel);

            // assert
            CustomersModel.Id.Should().NotBe(0, "because Identity should have been assigned by database.");
            Console.WriteLine("New ID: " + CustomersModel.Id);
            id = CustomersModel.Id;
        }

        [TestMethod]
        public void Update()
        {
            // arrange
            IcustomersRepository repository = CreateRepository();

            // act
            var CustomersModel = repository.GetCustomer(id);
            CustomersModel.FirstName = "Bob";
            repository.UpdateCustomer(CustomersModel);
            var modifiedCustomersModel = repository.GetCustomer(id);

            // assert
            modifiedCustomersModel.FirstName.Should().Be("Bob");

        }


        [TestMethod]
        public void Delete()
        {
            // arrange
            IcustomersRepository repository = CreateRepository();
            // act  
            repository.DeleteCustomer(id);
            // create a new repository for verification purposes
            var deletedEntity = repository.GetCustomer(id);
            // assert
            deletedEntity.Should().BeNull();
        }


      
    }

}
