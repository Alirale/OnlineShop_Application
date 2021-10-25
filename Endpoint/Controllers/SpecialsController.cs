using Application.Services;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialsController : Controller
    {
        private readonly ISpecialsService _specialsService;
        public SpecialsController(ISpecialsService specialsService)
        {
            _specialsService = specialsService;
        }

        /// <summary>
        /// دریافت لیست تمام موارد ویژه
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> Get()
        {
            var Specials = await _specialsService.GetAllSpecials();
            return Specials;
        }

        /// <summary>
        /// دریافت مورد ویژه با آیدی
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var Special = await _specialsService.GetSpecial(id);
            return Special;
        }


        /// <summary>
        /// افزودن مورد ویژه
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Post(CreateSpecial Special)
        {
            if (Special != null)
            {
                await _specialsService.Create(Special);
                return $"Special Feature Succesfully Added ";
            }

            return Ok();
        }

        /// <summary>
        /// ادیت مورد ویژه
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<object> Put(int id, EditSpecial Special)
        {
            if (Special != null)
            {
                await _specialsService.Edit(id, Special);
                return $"Special Feature Succesfully Edited in Database";
            }

            return Ok();
        }

        /// <summary>
        /// حذف مورد ویژه
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            await _specialsService.Delete(id);
            return $"Special Feature Succesfully Deleted from Database";
        }
    }
}
