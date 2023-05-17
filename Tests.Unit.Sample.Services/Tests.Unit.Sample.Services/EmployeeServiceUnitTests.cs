using Microsoft.EntityFrameworkCore;
using Sample.Repositories.DbContexts;

namespace Tests.Unit.Sample.Services
{
    [TestClass]
    public class EmployeeServiceUnitTests
    {
        [TestInitialize]
        public void IntializeServiceMockObject()
        {
            
        }

        //we can also use Test Setup and Test 
        [TestMethod]
        public void TestMethod_Verify_Delete_With_Valid_Inputs()
        {
        }

        [TestCleanup]
        public void CleanUpServiceMockObject()
        {

        }
    }
}