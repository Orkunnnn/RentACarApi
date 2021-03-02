using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Helpers
{
    public static class FileHelper
    {

        public static string CreatePath(IFormFile formFile)
        {
            var fileExtension = Path.GetExtension(formFile.FileName);
            var path = string.Concat(Environment.CurrentDirectory, @"\Images");
            var imageName = string.Concat(Guid.NewGuid().ToString(), fileExtension);
            var newPath = $@"{path}\{imageName}";
            return newPath;
        }

        public static IDataResult<string> Add(IFormFile formfile)
        {
            var targetPath = CreatePath(formfile);
            if (formfile.Length > 0)
            {
                using (var stream = new FileStream(targetPath, FileMode.Create))
                {
                    formfile.CopyTo(stream);
                }
            }
            return new SuccessDataResult<string>(targetPath);
        }

        public static IDataResult<string> Update(string sourcePath, IFormFile formFile)
        {
            var targetPath = CreatePath(formFile);
            if (sourcePath.Length > 0)
            {
                using var fileStream = new FileStream(targetPath, FileMode.Create);
                formFile.CopyTo(fileStream);
                File.Delete(sourcePath);
            }
            return new SuccessDataResult<string>(targetPath);
        }

        public static IResult Delete(string sourcePath)
        {

            File.Delete(sourcePath);
            return new SuccessResult();
        }
    }
}
