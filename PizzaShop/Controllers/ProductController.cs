using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuyetTC_ASS2_Repository.DTO;
using QuyetTC_ASS2_Repository.Implementations;
using QuyetTC_ASS2_Repository.Models;
using QuyetTC_ASS2_Repository.Repository;

namespace PizzaShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

       /* [HttpGet]
        public ActionResult<IEnumerable<Product>> Get(string? productName = null, int? categoryId = null) {
            var products = _unitOfWork.ProductRepository.GetAll(query =>
            {
                // Thêm điều kiện lọc theo tên sản phẩm (nếu được cung cấp)
                if (!string.IsNullOrEmpty(productName))
                {
                    query = query.Where(p => p.ProductName.Contains(productName));
                }
                // Thêm điều kiện lọc theo ID của danh mục (nếu được cung cấp)
                if (categoryId.HasValue)
                {
                    query = query.Where(p => p.CategoryId == categoryId.Value);
                }

                return query;
            });
            return Ok(products);
        }*/

        [HttpGet("{productId}")]
         public ActionResult GetProductId(int productId) {
            var product = _unitOfWork.ProductRepository.GetByID(productId);
            return Ok(product);
        }


        [HttpDelete("delete")]
        public IActionResult DeleteProduct(int productId = 0)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.GetByID(productId);
                if (product == null)
                {
                    return NotFound();
                }

                _unitOfWork.ProductRepository.Remove(product);
                _unitOfWork.Save(); 

                return NoContent();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateProduct")]
        public IActionResult UpdateProduct( [FromBody] ProductDTO productUpdateDTO)
        {
            try
            {
                var product = _unitOfWork.ProductRepository.GetByID(productUpdateDTO.ProductID);

                if (product == null)
                {
                    return NotFound(); // Trả về 404 Not Found nếu không tìm thấy sản phẩm
                }

                // Cập nhật thông tin sản phẩm từ DTO
                product.ProductName = productUpdateDTO.ProductName;
                product.UnitPrice = productUpdateDTO.UnitPrice;
                product.SupplierId = productUpdateDTO.SupplierId;
                product.UnitPrice = productUpdateDTO.UnitPrice;
                product.QuantityPerUnit = productUpdateDTO.QuantityPerUnit;
                product.ProductImg = productUpdateDTO.ProductImg;

                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Save();
                return NoContent(); // Trả về mã trạng thái 204 No Content nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



    }
}
