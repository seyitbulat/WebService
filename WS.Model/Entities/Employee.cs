using Infrastructure.Model;

namespace WS.Model.Entities
{
    public class Employee:IEntity
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
