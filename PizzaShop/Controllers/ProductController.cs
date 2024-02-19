using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopDomain.Repository;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Get() {
            var productsFromRepo = _unitOfWork.ProductRepository.GetAll();
            return Ok(productsFromRepo);
        }
    }
}
