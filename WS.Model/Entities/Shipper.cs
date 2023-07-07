using Infrastructure.Model;

namespace WS.Model.Entities
{
    public class Shipper : IEntity
    {
        public int ShipperId { get; set; }
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
    }
}
