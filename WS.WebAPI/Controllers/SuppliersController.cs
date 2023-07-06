using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierBs _supplierBs;

        public SuppliersController(ISupplierBs supplierBs)
        {
            _supplierBs = supplierBs;
        }

        [HttpGet]
        public List<Supplier> GetSuppliers()
        {
            return _supplierBs.GetSuppliers();
        }

        [HttpGet("getbycity")]
        public List<Supplier> GetByCity(string city)
        {
            return _supplierBs.GetByCity(city);
        }

        [HttpGet("getbycountry")]
        public List<Supplier> GetByCountry(string country)
        {
            return _supplierBs.GetByCountry(country);
        }

        [HttpGet("getbycompany")]
        public List<Supplier> GetByCompany(string company)
        {
            return _supplierBs.GetByCompanyName(company);  
        }
    }
}
