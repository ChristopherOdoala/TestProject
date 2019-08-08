using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Model.ViewModel;

namespace TestProject.Services
{
    public interface IFileUploadService
    {
        bool Upload(FileUploadModel model);
    }
}
