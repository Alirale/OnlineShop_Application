using Entities.RepositoryInterfaces;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUploaderCrudService
    {
        public Task<object> GetAllPics();
        public Task<object> GetPic(int id);
        public Task Create(IFormFile Picture);
        public Task Edit(int id, IFormFile Picture);
        public Task Delete(int id);

    }



    public class UploaderCrudService : IUploaderCrudService
    {
        private readonly IPicsRepository _picsRepository;

        public UploaderCrudService(IPicsRepository picsRepository)
        {
            _picsRepository = picsRepository;
        }

        public async Task<object> GetAllPics()
        {
            return await _picsRepository.GetAllPics();
        }

        public async Task<object> GetPic(int id)
        {
            var Pic = await _picsRepository.GetPicture(id);
            return (Pic);
        }


        public async Task Create(IFormFile Picture)
        {
            string uploadsFolder = Path.Combine(AppContext.BaseDirectory, "Uploads");
            string uniqueFileName = ProcessUploadedFile(Picture, uploadsFolder);
            await _picsRepository.AddPicPath(uniqueFileName);
        }



        public async Task Edit(int id, IFormFile Picture)
        {
            var ExistingPic = await _picsRepository.GetPicture(id);
            string FullfilePath = Path.Combine(AppContext.BaseDirectory, "Uploads", ExistingPic.ImagePath);
            string uploadsFolder = Path.Combine(AppContext.BaseDirectory, "Uploads");

            var Pic = await _picsRepository.GetPicture(id);

            if (FullfilePath != null)
            {
                File.Delete(FullfilePath);
            }

            string uniqueFileName = ProcessUploadedFile(Picture, uploadsFolder);

            await _picsRepository.EditPicPath(Pic, uniqueFileName);

        }



        public async Task Delete(int id)
        {
            var Picture = await _picsRepository.GetPicture(id);

            var CurrentImage = Path.Combine(AppContext.BaseDirectory, "Uploads", Picture.ImagePath);

            if (File.Exists(CurrentImage))
            {
                File.Delete(CurrentImage);
            }

            await _picsRepository.Delete(Picture);
        }


        private string ProcessUploadedFile(IFormFile Picture, string uploadsFolder)
        {
            string uniqueFileName = null;

            if (Picture != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Picture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
