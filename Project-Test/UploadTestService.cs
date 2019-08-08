using System;
using TestProject.Model.ViewModel;
using TestProject.Services;
using Xunit;

namespace Project_Test
{
    public class UploadTestService 
    {
        private FileUploadService _service { get; }
        public UploadTestService()
        {
            _service = new FileUploadService();
        }

        public static FileUploadModel model = new FileUploadModel
        {
                fileName = "uploadTest.png",
                base64String = "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"
        };

        [Fact]
        public void Upload_Test_ReturnOK()
        {
            var res = _service.Upload(model);
            Assert.True(res);
        }

    }
}
