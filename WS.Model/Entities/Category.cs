using Infrastructure.Model;

namespace WS.Model.Entities
{
    public class Category: IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public List<Product>? Products { get; set; }
    }
}
