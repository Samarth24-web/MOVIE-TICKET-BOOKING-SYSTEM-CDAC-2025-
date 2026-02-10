namespace MovieTicketBookingSystem.Services.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string folder);

    }
}
