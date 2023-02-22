using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemAPI.Modals;
using System.Text;

namespace StudentManagementSystemAPI.Services
{
    public class UploadPicService:IUploadPicService
    {
        Response response;
        public UploadPicService()
        {
            response = new Response();
        }

        public async Task<Response> PicUploadAsync(IFormFile file, Guid Id)
        {
            var folderName = Path.Combine("Assets");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
               /* StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb = sb.Append(Id);
                sb.Append(DateTime.Now);*/

                var fileName = Id.ToString();
                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = System.IO.File.Create(fullPath))
                {
                    await file.CopyToAsync(stream);
                }
                response.StatusCode= 200;
                response.Message = "File Uploaded Successfully";
                response.Data = fullPath;
                return response;
            }
            response.Message = "Please provide a file for successful upload";
            response.StatusCode= 400;
            response.Data= string.Empty;
            return response;
        }

    }
}


/*public async Task<IActionResult> Upload(Guid TeacherId)
{
    try
    {
        var formCollection = await Request.ReadFormAsync();
        var file = formCollection.Files.First();
        var folderName = Path.Combine("Resources", "Images");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        if (file.Length > 0)
        {
            //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = TeacherId.ToString();
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Ok(new { dbPath });
        }
        else
        {
            return BadRequest();
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex}");
    }
}*/