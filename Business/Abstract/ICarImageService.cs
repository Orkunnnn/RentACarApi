using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int imageId);
        IResult Add(CarImage image, IFormFile formFile);
        IResult Update(CarImage image, IFormFile formFile);
        IResult Delete(CarImage image);
        IDataResult<List<CarImage>> GetByCarId(int carId); 
        
    }
}
