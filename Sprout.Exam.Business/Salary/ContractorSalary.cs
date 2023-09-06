using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business
{
    public class ContractorSalary : ICalculateSalary
    {
        private const decimal dailySalary = 500;
        public decimal CalculateMonthly(CalculateSalaryParam param)
        {
            return Math.Round(dailySalary * param.workedDays);
        }
    }
}
