using StudentManagementSystemAPI.Modals;

namespace StudentManagementSystemAPI.Services
{
    public interface IUploadPicService
    {
        public Task<Response> PicUploadAsync(IFormFile file, Guid TeacherId);
    }
}
