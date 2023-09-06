using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business
{
    public class RegularEmployeeSalary : ICalculateSalary
    {
        private const decimal baseSalary = 20000;

        public decimal CalculateMonthly(CalculateSalaryParam employee)
        {
            decimal salaryLessAbsent = baseSalary - ((baseSalary / 22) * employee.absentDays);

            return Math.Round(salaryLessAbsent - (salaryLessAbsent * (12 / 100)), 2);
        }
    }
}
