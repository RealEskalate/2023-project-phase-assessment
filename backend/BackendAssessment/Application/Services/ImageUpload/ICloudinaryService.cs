using Microsoft.AspNetCore.Http;
namespace Backend.Application.Services.ImageUpload;

public interface ICloudinaryService
{
    Task<string> UploadImageAsync(IFormFile imageFile);
}
