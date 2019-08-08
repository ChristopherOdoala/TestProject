using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Model.ViewModel
{
    public class FileUploadModel
    {
        public Guid id { get; set; }
        public string fileName { get; set; }
        public string base64String { get; set; }
        public string uploader { get; set; }
        public string fileType { get; set; }
    }
}
