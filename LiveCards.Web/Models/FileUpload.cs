namespace LiveCards.Web.Models
{
    public class FileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUpload( IWebHostEnvironment hostEnvironment)
        {
            _webHostEnvironment = hostEnvironment;
        }

        public string SaveImage(IFormFile image, string folderName)
        {
            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(image.FileName);
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images/"+folderName);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return "/images/" + folderName +"/" + fileName;
        }
    }
}
