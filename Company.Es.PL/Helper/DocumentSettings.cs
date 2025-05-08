namespace Company.Es.PL.Helper
{
    public static class DocumentSettings
    {
        // upload 

        public static string Upload(IFormFile file, string folderName)
        {
            // name must be Unique 
            string name = $"{Guid.NewGuid()}{file.FileName}";

            // path proj directory + folder dir + fileName
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\files\\{folderName}", name);


            var fileStream = new FileStream(path, FileMode.Create);

            file.CopyTo(fileStream);

            return name;

        }

        //Delete

        public static void Delete(string fileName, string folderName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\files\\{folderName}", fileName);

            if (File.Exists(path))
                File.Delete(path);


        }
    }
}

//using Microsoft.AspNetCore.Hosting;

//public static class DocumentSettings
//{
//    public static string Upload(IFormFile file, string folderName, IWebHostEnvironment webHostEnvironment)
//    {
//        // 1. Get the correct wwwroot path dynamically
//        string folderPath = Path.Combine(webHostEnvironment.WebRootPath, "files", folderName);

//        // 2. Create directory if it doesn't exist
//        if (!Directory.Exists(folderPath))
//            Directory.CreateDirectory(folderPath);

//        // 3. Generate a unique filename
//        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}"; // Fix: Use Path.GetExtension() instead of full filename
//        string filePath = Path.Combine(folderPath, fileName);

//        // 4. Save the file
//        using var fileStream = new FileStream(filePath, FileMode.Create);
//        file.CopyTo(fileStream);

//        return fileName;
//    }

//    public static void Delete(string fileName, string folderName, IWebHostEnvironment webHostEnvironment)
//    {
//        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "files", folderName, fileName);

//        if (File.Exists(filePath))
//            File.Delete(filePath);
//        else
//            Console.WriteLine("File not found: " + filePath); // Log for debugging
//    }
//}
