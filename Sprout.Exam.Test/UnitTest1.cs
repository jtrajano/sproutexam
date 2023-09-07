using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sprout.Exam.Business;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Repository.IRepository;
using Sprout.Exam.Models;
using Sprout.Exam.WebApp.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Sprout.Exam.Test
{
    [TestClass]
    public class ComputeSalaryTests
    {
        IUnitOfWork _uow;
        public ComputeSalaryTests()
        {
         
        }

        [TestMethod]
        [Description("Calculate Regular Employee salary is correct")]
        public void Compute_Regular_Employee_Salary()
        {

            CalculateSalaryParam p = new CalculateSalaryParam
            {
                absentDays = 1
            };

            ICalculateSalary calculateSalary = CalculateSalaryFactory.GetCalculateSalary(EmployeeType.Regular);

            decimal salary = calculateSalary.CalculateMonthly(p);
            byte decimals = (byte)((Decimal.GetBits(salary)[3] >> 16) & 0x7F);

            if (decimals > 2)
                Assert.Fail("Decimal is greater than two decimals");

            Assert.AreEqual(salary,19090.91m);

        }


        [TestMethod]

        public void Compute_Contract_Employee_Salary()
        {

            CalculateSalaryParam p = new CalculateSalaryParam
            {
                workedDays = 2
            };

            ICalculateSalary calculateSalary = CalculateSalaryFactory.GetCalculateSalary(EmployeeType.Contractual);

            decimal salary = calculateSalary.CalculateMonthly(p);
            byte decimals = (byte)((Decimal.GetBits(salary)[3] >> 16) & 0x7F);

            if (decimals > 2)
                Assert.Fail("Decimal is greater than two decimals");

            Assert.AreEqual(salary, 1000m);

        }

        [TestMethod]
        public void GetEmployeeWIthSameId()
        {
            // Arrange

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup((x) => x.Employee.Find(1)).Returns(Task.FromResult(new Employee { Id = 1 }));

            EmployeesController controller = new EmployeesController(mockUnitOfWork.Object);


            // Act
            IActionResult actionResult = controller.GetById(1).Result;

            var contentResult = actionResult as OkObjectResult;
            Employee e = (Employee)contentResult.Value;

            // Assert
            Assert.IsNotNull(e);
            Assert.AreEqual(1, e.Id);
        }

        [TestMethod]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            EmployeesController controller = new EmployeesController(mockUnitOfWork.Object);

            mockUnitOfWork.Setup((x) => x.Employee.Find(1)).Returns(Task.FromResult(new Employee { Id = 1 }));

            // Act
            IActionResult actionResult = controller.Delete(1).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
        }


    }
}
