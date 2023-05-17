using Microsoft.EntityFrameworkCore;
using Sample.Domains.Entities;
using Sample.Repositories;
using Sample.Repositories.DbContexts;

namespace Tests.Unit.Sample.Repositories
{
    //By using Moq I need to create AsyncQueryable and due to short time I am using InMemory DB
    [TestClass]
    public class EmployeeRepositoryUnitTests
    {
        IEmployeeRepository employeeRespository;
        IEmployeeDbContext dbContext;

        [TestInitialize]
        public void InMomoryDbContextOptions()
        {
            DbContextOptions options = new DbContextOptionsBuilder<EmployeeDbContext>()
                        .UseInMemoryDatabase(databaseName: "EmployeeDb")
                        .Options;
            dbContext = new EmployeeDbContext(options);
            employeeRespository = new EmployeeRepository(dbContext);
        }

        //we can also use Test Setup and Test 
        [TestMethod]
        public void TestMethod_Verify_Delete_With_Valid_Inputs()
        {
            Task.Run(async () =>
            {
                await employeeRespository.CreateAsync(new EmployeeEntity { EmployeeId = 1, Age = 32, FirstName = "Adam", LastName = "Smith", Gender = "Male" });
                await employeeRespository.CreateAsync(new EmployeeEntity { EmployeeId = 2, Age = 49, FirstName = "Jamima", LastName = "Smith", Gender = "Female" });
                await employeeRespository.CreateAsync(new EmployeeEntity { EmployeeId = 3, Age = 32, FirstName = "Anita", LastName = "Nemoli", Gender = "Female" });
                await employeeRespository.CreateAsync(new EmployeeEntity { EmployeeId = 4, Age = 32, FirstName = "Ramis", LastName = "David", Gender = "Male" });

                var result = await employeeRespository.DeleteAsync(3);
                Assert.AreEqual(result, true);

                var employees = await employeeRespository.GetAsync();
                Assert.AreEqual(employees.Count(), 3);

            }).GetAwaiter().GetResult();
        }

        [TestCleanup]
        public void InMomoryDbCleanup()
        {
            Task.Run(async () =>
            {
                await dbContext.DisposeAsync();

            }).GetAwaiter().GetResult();
        }
    }
}