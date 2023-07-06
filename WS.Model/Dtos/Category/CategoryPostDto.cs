using Infrastructure.Model;

namespace WS.Model.Dtos.Category
{
    public class CategoryPostDto:IDto
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
