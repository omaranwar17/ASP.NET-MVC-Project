using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BUS_L_10.Services.Attachment
{
    public class AttachmentService : IAttachmentService
    {
        List<string> _allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" };
        const int maxFileSize = 2 * 1024 * 1024; // 2 MB
        public string? Upload(IFormFile file, string FolderName)
        {
            var extention = Path.GetExtension(file.FileName);
            if (!_allowedExtensions.Contains(extention))
            {
                return null;
            }
            if (file.Length > maxFileSize || file.Length == 0)
           {
                return null;
           }
            //var folderPath = $"{Directory.GetCurrentDirectory()}//wwwroot//Files//{FolderName}";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files",  FolderName);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(folderPath, fileName);
            using FileStream fs = new FileStream(filePath, FileMode.Create);
           
            file.CopyTo(fs);
            return fileName;

            // Implementation for uploading file
            return "File uploaded successfully";
        }

        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

     
    }
}
