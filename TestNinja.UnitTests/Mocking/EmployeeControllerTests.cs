using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {

        [Test]
        public void DeleteEmployee_RedirectsOK_ReturnsEmployeesRedirect()
        {
            var repository = new Mock<IEmployeeRepository>();
            EmployeeController? controller = new EmployeeController (repository.Object);

            var result = controller.DeleteEmployee(1);

            repository.Verify(r => r.DeleteEmployee(1));
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }

    }
}
