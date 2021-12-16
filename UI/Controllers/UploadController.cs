using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class UploadController : Controller
    {


        private IUploadService _iuploadservice;

        public UploadController(IUploadService uploadService)
        {
            _iuploadservice = uploadService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            var bytes = new byte[file.OpenReadStream().Length + 1];
            file.OpenReadStream().Read(bytes, 0, bytes.Length);
            _iuploadservice.SingleUplaod(file.FileName, bytes);
            return View();
        }

       





    }
}
