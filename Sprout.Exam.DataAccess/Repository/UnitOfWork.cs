using Sprout.Exam.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context, IEmployeeRepository employee)
        {

            _context = context;
            Employee = employee;

        }

        public IEmployeeRepository Employee { get; set; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
