using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sprout.Exam.DataAccess;
using Sprout.Exam.DataAccess.Repository;
using Sprout.Exam.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Sprout.Exam.Test
{
    public static class Helper
    {
        private static IServiceProvider Provider() {

            var services = new ServiceCollection();

            //services.AddDbContext<ApplicationDbContext>(options =>
            // options.UseSqlServer(
            //     System.Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services.BuildServiceProvider();

        }
        public static T GetRequiredService<T>()
        {
            var provider = Provider();
            return provider.GetRequiredService<T>();
        
        }
    }
}
