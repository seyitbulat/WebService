using Infrastructure.Model;

namespace WS.Model.Dtos.OrderDetail
{
    public class OrderDetailGetDto : IDto
    {
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
    }
}
