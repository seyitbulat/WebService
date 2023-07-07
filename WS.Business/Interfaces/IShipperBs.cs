using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IShipperBs
    {
        Shipper GetById(int id);
        List<Shipper> GetByName(string name);
        List<Shipper> GetByPhone(string phone);
        List<Shipper> GetShippers();

        void AddShipper(Shipper shipper);
        void RemoveShipper(Shipper shipper);
        void UpdateShipper(Shipper shipper);
    }
}
