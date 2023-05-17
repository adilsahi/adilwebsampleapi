using Microsoft.EntityFrameworkCore;
using Sample.Domains.Entities;
using Sample.Repositories;
using Sample.Repositories.DbContexts;

namespace Tests.Unit.Sample.Repositories
{
    [TestClass]
    public class EmployeeRepositoryUnitTests
    {
        private DbContextOptions options;

        [TestInitialize]
        public void InMomoryDbContextOptions()
        {
            options = new DbContextOptionsBuilder<EmployeeDbContext>()
                        .UseInMemoryDatabase(databaseName: "EmployeeDb")
                        .Options;
        }

        //we can also use Test Setup and Test 
        [TestMethod]
        public void TestMethod_Verify_Delete_With_Valid_Inputs()
        {
            Task.Run(async () =>
            {
                using (var context = new EmployeeDbContext(options))
                {
                    var employeeRespository = new EmployeeRepository(context);

                    await employeeRespository.CreateAsync(new EmployeeEntity { EmployeeId =1, Age = 32, FirstName="Adam",LastName="Smith", Gender="Male" });
                    await employeeRespository.CreateAsync(new EmployeeEntity { EmployeeId = 2, Age = 49, FirstName = "Jamima", LastName = "Smith", Gender = "Female" });
                    await employeeRespository.CreateAsync(new EmployeeEntity { EmployeeId = 3, Age = 32, FirstName = "Anita", LastName = "Nemoli", Gender = "Female" });
                    await employeeRespository.CreateAsync(new EmployeeEntity { EmployeeId = 4, Age = 32, FirstName = "Ramis", LastName = "David", Gender = "Male" });
                }

                using (var context = new EmployeeDbContext(options))
                {
                    var employeeRespository = new EmployeeRepository(context);

                    var result = await employeeRespository.DeleteAsync(3);
                    Assert.AreEqual(result, true);

                    var employees = await employeeRespository.GetAsync();
                    Assert.AreEqual(employees.Count(), 3);
                }
            }).GetAwaiter().GetResult();
        }

        [TestCleanup]
        public void InMomoryDbCleanup()
        {
            Task.Run(async () =>
            {
                using (var context = new EmployeeDbContext(options))
                {
                    await context.DisposeAsync();
                }
            }).GetAwaiter().GetResult();
        }
    }
}