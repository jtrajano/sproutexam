using Sprout.Exam.DataAccess.Repository.IRepository;
using Sprout.Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repository
{
    public class EmployeeRepository: Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;

        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public void Update(Employee obj)
        {
            _db.Employee.Update(obj);
        }
    }
}
