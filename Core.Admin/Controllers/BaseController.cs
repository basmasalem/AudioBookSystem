using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Admin.Models;
using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeTypes;

namespace Core.Admin.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IRepositoryWrapper _repoWrapper;
        public int ItemPerPage = 15;
        public BaseController(IRepositoryWrapper repoWrapper, IWebHostEnvironment webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _webHostEnvironment = webHostEnvironment;
        }
      
        public UserData CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var claims = User.Claims;
                    return new UserData {
                       UserId=int.Parse(claims?.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.OrdinalIgnoreCase))?.Value),
                       Email= claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase))?.Value,
                       Name= claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name, StringComparison.OrdinalIgnoreCase))?.Value,
                       Image= claims?.FirstOrDefault(x => x.Type.Equals("Image", StringComparison.OrdinalIgnoreCase))?.Value,
                       UserType= claims?.FirstOrDefault(x => x.Type.Equals("UserType", StringComparison.OrdinalIgnoreCase))?.Value
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        [HttpPost]
        public IActionResult RemoveUpload(string id, int type)
        {
            string FolderName = type == 1 ? "Attachments/Images/" : type == 2 ? "Attachments/Files" : "Attachments/Audios";
            
            try
            {
                int attachId = int.Parse(id.Split('.')[0]);
       
                // Check if file exists with its full path    
                if (System.IO.File.Exists(Path.Combine(_webHostEnvironment.WebRootPath, FolderName,id)))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    // If file found, delete it    
                    System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, FolderName,id));
                    _repoWrapper.attachmentRepository.Delete(_repoWrapper.attachmentRepository.Find(attachId));
                    _repoWrapper.attachmentRepository.Commit();
                }
                else return Json("-2");
            }
            catch (IOException ex)
            {
                return Json("-1");
            }
            return Json("1");
        }
        [HttpPost]
        public ActionResult UploadFile()
        {

            try
            {
                var files = Request.Form.Files;
                IFormFile file = files.FirstOrDefault();
                if (file.Length > 0)
                {
                    int typeId = 1; //img
                    string FolderName = "Attachments/Images";
                    if (file.ContentType.Contains("pdf") || file.ContentType.Contains("doc") || file.ContentType.Contains("docx"))
                    { 
                        typeId = 2;
                        FolderName = "Attachments/Files";
                    }
                    else if (file.ContentType.Contains("mp3") || file.ContentType.Contains("wav") || file.ContentType.Contains("WAV"))
                    { 
                        typeId = 3;
                        FolderName = "Attachments/Audios";
                    }

                    var attachment = new Attachment {TypeId = typeId, CreationDate = DateTime.Now, Title = Path.GetFileName(file.FileName) };
                    _repoWrapper.attachmentRepository.Add(attachment);
                    _repoWrapper.attachmentRepository.Commit();
                    string _FileName = Path.GetFileName(file.FileName);
                    string _extension = MimeTypeMap.GetExtension(file.ContentType);
                    //string _extension = Path.GetExtension(file.FileName);
                    string hypoName = "/"+ FolderName + "/" + attachment.AttachmentId.ToString() + _extension;
                    string upload = Path.Combine(_webHostEnvironment.WebRootPath, FolderName);
                    string fullPath = Path.Combine(upload, attachment.AttachmentId.ToString() + _extension);
                    file.CopyTo(new FileStream(fullPath, FileMode.Create));



                    return Json(new
                    {
                        path = hypoName,
                        id = attachment.AttachmentId.ToString(),
                        src = attachment.AttachmentId.ToString()+_extension,
                        name = _FileName,
                        date = DateTime.Now.ToString("yyyy-MM-dd"),
                    });
                }
                return Json(new { message = "Sorry No File To Upload .." });
            }
            catch (Exception ex)
            {
                return Json(new { message = "Sorry Can't Upload Your File .." + ex.Message });
            }
        }
        public IActionResult GetImageExtension(int img)
        {
            if (img == 0)
                return Content( ".jpg");
            var attach = _repoWrapper.attachmentRepository.Find(img);
            string Extension = attach != null ? "." + attach.Title.Split('.')[1] : string.Empty;
            return Content( Extension);
        }
    }
}
