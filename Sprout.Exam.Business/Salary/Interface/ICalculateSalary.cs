using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business
{
    public interface ICalculateSalary
    {
        decimal CalculateMonthly(CalculateSalaryParam param);
    }
}
