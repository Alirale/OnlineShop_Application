using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicUploaderController : Controller
    {

        private readonly IUploaderCrudService _uploadCrudService;


        public PicUploaderController(IUploaderCrudService uploadCrudService)
        {
            _uploadCrudService = uploadCrudService;
        }

        /// <summary>
        /// دریافت مشخصات تمامی عکس ها
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> Get()
        {
            var AllPics = await _uploadCrudService.GetAllPics();
            return AllPics;
        }

        /// <summary>
        /// دریافت مشخصات عکس توسط آیدی
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var Pic = await _uploadCrudService.GetPic(id);
            return Pic;
        }

        /// <summary>
        /// افزودن عکس در فولدر Uploads + ذخیره نام فایل در دیتابیس
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Post(IFormFile Picture)
        {
            if (Picture != null)
            {
                await _uploadCrudService.Create(Picture);
                return $"Picture Succesfully Added to Database";
            }

            return Ok();
        }

        /// <summary>
        /// ادیت عکس در فولدر اپلودز
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<object> Put(int id, IFormFile Picture)
        {
            if (Picture != null)
            {
                await _uploadCrudService.Edit(id, Picture);
                return $"Picture Succesfully Eddited in Database";
            }

            return Ok();
        }

        /// <summary>
        /// حذف عکس از فولدر آپلودز و دیتابیس
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            await _uploadCrudService.Delete(id);
            return $"Picture Succesfully Deleted from Database"; ;
        }

    }
}
