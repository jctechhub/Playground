using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;
using Uplift.Utility;

namespace Uplift.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class WebImageController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WebImageController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            WebImages imageObj = new WebImages();
            if (id == null)
            {

            }
            else
            {
                imageObj = _db.WebImages.SingleOrDefault(m => m.Id == id);
                if (imageObj == null)
                {
                    return NotFound();
                }
            }
            return View(imageObj);

        }


        /// <summary>
        /// NOTE: This is different to the repo pattern approach, this is direct calling to the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imageObj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(int id, WebImages imageObj)
        {
            if (ModelState.IsValid)
            {
                //NOTE: Getting the image from the upload files, and put it in database. 
                var files = HttpContext.Request.Form.Files;
                if(files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1= files[0].OpenReadStream())
                    {
                        using (var ms1= new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    imageObj.Picture = p1;
                }

                if (imageObj.Id == 0)
                {
                    _db.WebImages.Add(imageObj);
                }
                else
                {
                    var imageFromDb = _db.WebImages.Where(c => c.Id == id).FirstOrDefault();

                    imageFromDb.Name = imageObj.Name;
                    if (files.Count > 0)
                    {
                        imageFromDb.Picture = imageObj.Picture;
                    }
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(imageObj);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Json(new { data = _db.WebImages.ToList() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _db.WebImages.Find(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _db.WebImages.Remove(objFromDb);
            _db.SaveChanges();
            return Json(new { success = true, message = "Delete successful." });

        }


        #endregion
    }
}