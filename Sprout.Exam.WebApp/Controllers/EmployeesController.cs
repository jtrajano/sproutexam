using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Repository.IRepository;
using Sprout.Exam.Models;
using Sprout.Exam.Business;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.Employee.GetAll();

            //var result = await Task.FromResult(StaticEmployees.ResultList);
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _unitOfWork.Employee.Find(id);
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {

        


            var item = await _unitOfWork.Employee.Find(input.Id);
            if (item == null) return NotFound();



            item.FullName = input.FullName;
            item.Tin = input.Tin;
            item.Birthdate = input.Birthdate;
            item.TypeId = input.TypeId;

            await _unitOfWork.Save();

            return Ok(item);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {

       
            Employee employee = new Employee
            {
                Birthdate = input.Birthdate,
                FullName = input.FullName,
                Tin = input.Tin,
                TypeId = input.TypeId

            };

            _unitOfWork.Employee.Add(new Employee
            {
                Birthdate = input.Birthdate,
                FullName = input.FullName,
                Tin = input.Tin,
                TypeId = input.TypeId

            });

            await _unitOfWork.Save();

            return Created($"/api/employees/{employee.Id}", employee.Id);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
         
            var result = await _unitOfWork.Employee.Find(id);

            if (result == null) return NotFound();
            _unitOfWork.Employee.Remove(result);
            await _unitOfWork.Save();
            return Ok(id);
        }



        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(CalculateSalaryParam param)
        {
            var result = await _unitOfWork.Employee.Find(param.id);

            if (result == null) return NotFound();
            var type = (EmployeeType) result.TypeId;

            ICalculateSalary calculateSalary = CalculateSalaryFactory.GetCalculateSalary(type);

            return Ok(calculateSalary.CalculateMonthly(param));

        }

    }
}
