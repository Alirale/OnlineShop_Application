using Application.Services;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PossibleExtraFeaturesController : Controller
    {

        private readonly IExtraFeaturesService _extraFeatures;
        public PossibleExtraFeaturesController(IExtraFeaturesService extraFeatures)
        {
            _extraFeatures = extraFeatures;
        }

        /// <summary>
        /// دریافت تمامی موارد ممکن برای افزودن مورد اضافه در محصولات
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> Get()
        {
            var Products = await _extraFeatures.GetAllFeatures();
            return Products;
        }

        /// <summary>
        /// دریافت مورد ممکن با آیدی برای افزودن مورد اضافه در محصولات
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var Product = await _extraFeatures.GetFeature(id);
            return Product;
        }

        /// <summary>
        /// افزودن مورد ممکن برای افزودن مورد اضافه در محصولات
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Post(CreateFeature Feature)
        {
            if (Feature != null)
            {
                await _extraFeatures.Create(Feature);
                return $"Extra Feature Succesfully Added to Possible Features";
            }

            return Ok();
        }

        /// <summary>
        /// ویرایش مورد ممکن برای افزودن مورد اضافه در محصولات
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<object> Put(int id, EditFeature Feature)
        {
            if (Feature != null)
            {
                await _extraFeatures.Edit(id, Feature.Name);
                return $"Possible Feature Succesfully Edited in Database";
            }

            return Ok();
        }

        /// <summary>
        /// حذف مورد ممکن برای افزودن مورد اضافه در محصولات
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            await _extraFeatures.Delete(id);
            return $"Possible Feature Succesfully Deleted from Database";
        }
    }
}
