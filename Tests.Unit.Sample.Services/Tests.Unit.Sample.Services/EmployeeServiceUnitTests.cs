

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Sample.Domains.Entities;
using Sample.Domains.Models;
using Sample.Infrastructure.UnitTest;
using Sample.Repositories;
using Sample.Repositories.DbContexts;
using Sample.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Tests.Unit.Sample.Services
{
    [TestClass]
    public class EmployeeServiceUnitTests
    {
        IEmployeeService employeeService;
        IEmployeeDbContext dbContext;

        [TestInitialize]
        public void IntializeServiceMockObject()
        {
            DbContextOptions options = new DbContextOptionsBuilder<EmployeeDbContext>()
            .UseInMemoryDatabase(databaseName: "EmployeeDb")
            .Options;
            dbContext = new EmployeeDbContext(options);
            IEmployeeRepository employeeRespository = new EmployeeRepository(dbContext);
            employeeService = new EmployeeService(employeeRespository);
        }

        //we can also use Test Setup and Test 
        [TestMethod]
        public void TestMethod_Insert_NewRecord_True_Case()
        {
            Task.Run(async () =>
            {
                var entity = new EmployeeModel { Age = 17, FirstName = "John", LastName = "Swagger", Gender = "Male" };

                var result = await employeeService.CreateAsync(entity);
                Assert.AreNotEqual(result, null);
                Assert.AreNotEqual(result, -1);
            }).GetAwaiter().GetResult();
        }


        //we can also use Test Setup and Test 
        [TestMethod]
        public void TestMethod_Get_AllRecords_True_Case()
        {
            Task.Run(async () =>
            {
                await employeeService.CreateAsync(new EmployeeModel { Age = 32, FirstName = "Adam", LastName = "Smith", Gender = "Male" });

                var result = await employeeService.GetAllByFilterAsync(null);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.Count(), 1);

            }).GetAwaiter().GetResult();
        }

        [TestCleanup]
        public void CleanUpServiceMockObject()
        {
            Task.Run(async () =>
            {
                await dbContext.DisposeAsync();

            }).GetAwaiter().GetResult();
        }
    }
}