using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Model;
using TestProject.Model.ViewModel;

namespace TestProject.Services
{
    public class FileUploadService : IFileUploadService
    {

        public bool Upload(FileUploadModel model)
        {
            try
            {
                //Splits the name and the extension
                var initialFileName = model.fileName.Split(new[] { "." }, StringSplitOptions.None);
                var fileDate = DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
                var lastFileName = string.Concat(initialFileName.First(), $"_{fileDate}", "." + initialFileName.Last());
                
                //Gets the path to save the file
                var path = $"C:/Users/23470/source/repos/TestProject/{lastFileName}";
                Byte[] bytes = Convert.FromBase64String(model.base64String);

                //Writes the file into the path
                File.WriteAllBytes(path, bytes);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
