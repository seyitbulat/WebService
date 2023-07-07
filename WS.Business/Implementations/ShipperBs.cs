using WS.Business.Interfaces;
using WS.DataAccsess.Interfaces;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class ShipperBs : IShipperBs
    {
        private readonly IShipperRepository _repo;

        public ShipperBs(IShipperRepository repo)
        {
            _repo = repo;
        }

        public void AddShipper(Shipper shipper)
        {
            _repo.Insert(shipper);
        }

        public Shipper GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Shipper> GetShippers()
        {
            return _repo.GetAll();
        }

        public List<Shipper> GetByName(string name)
        {
            return _repo.GetByName(name);
        }

        public List<Shipper> GetByPhone(string phone)
        {
            return _repo.GetByPhone(phone);
        }

        public void RemoveShipper(Shipper shipper)
        {
            throw new NotImplementedException();
        }

        public void UpdateShipper(Shipper shipper)
        {
            throw new NotImplementedException();
        }
    }
}
