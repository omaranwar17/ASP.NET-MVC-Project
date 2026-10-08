using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APP_BUS_L_10.Services.Attachment
{
    public interface IAttachmentService
    {
        //uplode
        public string? Upload(IFormFile file, string FolderName);
       



        //delete
        public bool Delete(string filePath);
    }
}
