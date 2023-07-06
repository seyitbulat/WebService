using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Model.Dtos.Employee
{
    public class EmployeeGetDto:IDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
