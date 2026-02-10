using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Options;
using MovieTicketBookingSystem.AwsUtils;
using MovieTicketBookingSystem.Services.Interfaces;

namespace MovieTicketBookingSystem.Services.Implementation
{
    public class S3FileStorageService : IFileStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly AwsSettings _aws;

        public S3FileStorageService(
            IAmazonS3 s3Client,
            IOptions<AwsSettings> options)
        {
            _s3Client = s3Client;
            _aws = options.Value;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            var allowedTypes = new[] { "image/jpeg", "image/png", "image/webp" };
            if (!allowedTypes.Contains(file.ContentType))
                throw new ArgumentException("Only jpg, png, webp allowed");

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var key = $"{folder}/{fileName}";

            try
            {
                using var stream = file.OpenReadStream();

                var request = new PutObjectRequest
                {
                    BucketName = "movie-booking-images",
                    Key = key,
                    InputStream = stream,
                    ContentType = file.ContentType,
                    CannedACL = S3CannedACL.PublicRead
                };

                await _s3Client.PutObjectAsync(request);

                return $"https://{_aws.BucketName}.s3.{_aws.Region}.amazonaws.com/{key}";
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception($"S3 upload failed: {ex.Message}");
            }
        }

    }
}
