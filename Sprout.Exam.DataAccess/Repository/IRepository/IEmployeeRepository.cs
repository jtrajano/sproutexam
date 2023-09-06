﻿using Sprout.Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        void Update(Employee obj);
        Task Save();
    }
}
