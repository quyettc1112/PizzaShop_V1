using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuyetTC_ASS2_Repository.Models;
using QuyetTC_ASS2_Repository.Repository;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       /* [HttpGet]
        public ActionResult Get()
        {
           var cateFromRepo = _unitOfWork.CategoryRepository.GetAll();
            return Ok(cateFromRepo);
        }*/



    }
}
