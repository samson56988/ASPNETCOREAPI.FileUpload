using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UploadAPI.Controllers
{
    [Route("api/demo")]
    public class DemoController : Controller
    {


        private IWebHostEnvironment _webHostEnvironment;


        public DemoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("singleupload")]
        public IActionResult Index(IFormFile  file)
        {
            try
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Upload", file.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("multipleupload")]
        public IActionResult Upload(IFormFile[] files)
        {
            try
            {
                if (files != null && files.Length > 0)
                {
                    foreach (var file in files)
                    {
                        var path = Path.Combine(_webHostEnvironment.WebRootPath, "Upload", file.FileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                    
                }
                
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
