using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Models
{
    public class Employee
    {
     
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Tin { get; set; }

        [Column("EmployeeTypeId")]

        [Required]
        public int TypeId { get; set; }

        [NotMapped]
        public string BirthDateToString { get { return this.Birthdate.ToString("dd/MM/yyyy"); } }
    }
}
