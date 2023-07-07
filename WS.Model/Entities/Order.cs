using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Model.Entities
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public Decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCounty { get; set; }

        public OrderDetail orderDetail { get; set; }
        public Shipper shipper { get; set; }
        public Customer customer { get; set; }
        public Employee employee { get; set; }
    }
}
