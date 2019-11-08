using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository.IRepository;

namespace SampleUplift.Areas.Admin.Controllers
{
    [Area("Admin")]  //NOTE: this defines the route
    [Authorize]

    public class ServiceController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment; //this is from DI, for image upload 

        public ServiceController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }



        #region API Calls
        public IActionResult GetAll()
        {
            //NOTE: IncludeProperties: use eager loading to populate object in binding. 
            return Json(new { data = _unitOfWork.Service.GetAll(includeProperties: "Category,Frequency") });
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var serviceFromDb = _unitOfWork.Service.Get(id);
        //    string webRootPath = _hostEnvironment.WebRootPath;
        //    var imagePath = Path.Combine(webRootPath, serviceFromDb.ImageUrl.TrimStart('\\'));
        //    if (System.IO.File.Exists(imagePath))
        //    {
        //        System.IO.File.Delete(imagePath);
        //    }

        //    if (serviceFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting." });
        //    }

        //    _unitOfWork.Service.Remove(serviceFromDb);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Deleted Successfully." });
        //}

        #endregion


    }
}