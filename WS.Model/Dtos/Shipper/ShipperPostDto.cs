using Infrastructure.Model;

namespace WS.Model.Dtos.Shipper
{
    public class ShipperPostDto:IDto
    {
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }
    }
}
