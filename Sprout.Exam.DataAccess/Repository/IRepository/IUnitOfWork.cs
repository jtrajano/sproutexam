using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {


        IEmployeeRepository Employee { get; set; }

        Task Save();
    }
}
