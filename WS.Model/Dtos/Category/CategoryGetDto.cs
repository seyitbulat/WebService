using Infrastructure.Model;

namespace WS.Model.Dtos.Category
{
    public class CategoryGetDto:IDto
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
