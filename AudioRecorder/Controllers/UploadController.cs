using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordAndUploadAudio.Controllers
{
    public class UploadController : Controller
    {
        public JsonResult Recording(HttpPostedFileBase file)
        {
            byte[] fileBytes = null;
            var errorMessage = "";
            var hasError = false;

            try
            {
                fileBytes = new byte[file.InputStream.Length];
                file.InputStream.Read(fileBytes, 0, (int)file.InputStream.Length);
            }
            catch (Exception ex)
            {
                hasError = true;
                errorMessage = ex.Message;
            }

            var filePath = Server.MapPath("~/Recordings/" + Guid.NewGuid().ToString("N") + ".wav");
            System.IO.File.WriteAllBytes(filePath, fileBytes);

            return Json(new {
                HasError = hasError,
                ErrorMessage = errorMessage,
            });
        }

    }
}
