using DAL.UnitOfWork;
using Entity.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass]
    public class EmployeeServiceTest
    {

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var mockIUnitOfWork = new Mock<IUnitOfWork>();

            var expectedResult = new Employee { Id = Guid.NewGuid(), FirstName = "aa" };

            mockIUnitOfWork.Setup(x => x.EmployeeRepository.GetById(expectedResult.Id))
                .Returns(expectedResult);

            var employeeService = new EmployeeService(mockIUnitOfWork.Object);

            // Act
            var employee = employeeService.GetById(expectedResult.Id);

            // Assert
            Assert.AreEqual(expectedResult.Id, employee.Id);
        }

    }
}
