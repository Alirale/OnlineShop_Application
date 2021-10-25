using Application.Services;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCrudController : Controller
    {

        private readonly IProductsCrudService _productsCrudService;
        public ProductCrudController(IProductsCrudService productsCrudService)
        {
            _productsCrudService = productsCrudService;
        }

        /// <summary>
        /// برای گرفتن تمامی محصولات همراه با لیست کامنت ها و موارد متفاوت و ویژه
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> Get()
        {
            var Products = await _productsCrudService.GetAllProducts();
            return Products;
        }

        /// <summary>
        /// برای گرفتن محصول توسط آیدی همراه با لیست کامنت ها و موارد متفاوت و ویژه
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var Product = await _productsCrudService.GetProduct(id);
            return Product;
        }

        /// <summary>
        /// برای اد کردن محصول ،جهت دریافت آیدی عکس و موارد اضافه و به قسمت دریافت تمامی موارد در کنترلر های دیگر مراجعه کنید
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Post(CreateProductDTO Product)
        {
            if (Product != null)
            {
                await _productsCrudService.Create(Product);
            }

            return Ok();
        }

        /// <summary>
        /// برای ادیت کردن محصول ،جهت دریافت آیدی عکس و موارد اضافه و به قسمت دریافت تمامی موارد در کنترلر های دیگر مراجعه کنید
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<object> Put(int id, CreateProductDTO Product)
        {
            if (Product != null)
            {
                await _productsCrudService.Edit(id, Product);
            }

            return Ok();
        }

        /// <summary>
        /// برای اد کردن موارد اضافه به یک محصول توسط آیدی
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<object> Put(int id, UpdateExtrasList updateExtrasList)
        {
            await _productsCrudService.AddExtrasToProduct(id, updateExtrasList);

            return Ok();
        }

        /// <summary>
        /// برای حذف کردن محصول از دیتابیس
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            await _productsCrudService.Delete(id);
            return Ok();
        }
    }
}
