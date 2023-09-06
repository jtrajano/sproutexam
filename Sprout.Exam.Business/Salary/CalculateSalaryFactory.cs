using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business
{
    public static class CalculateSalaryFactory
    {
        public static ICalculateSalary GetCalculateSalary(EmployeeType empType) {

            switch (empType)
            {
                case EmployeeType.Regular:
                    return new RegularEmployeeSalary();
                case EmployeeType.Contractual:
                    return new ContractorSalary();
                default:
                    throw new Exception("Unknown Employee Type!");
            }

        }
    }
}
