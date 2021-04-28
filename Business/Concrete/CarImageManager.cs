using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _imageDal;

        public CarImageManager(ICarImageDal imageDal)
        {

            _imageDal = imageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_imageDal.Get(i => i.CarImageId == imageId));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage image, IFormFile formFile)
        {
            var result = BusinessRule.Run(CheckIfImageLimitCorrect(image.CarId));
            if (result != null)
            {
                return result;
            }
            image.ImagePath = FileHelper.Add(formFile).Data;
            _imageDal.Add(image);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage image, IFormFile formFile)
        {
            image.ImagePath = FileHelper.Update(image.ImagePath, formFile).Data;
            _imageDal.Update(image);
            return new SuccessResult();
        }

        public IResult Delete(CarImage image)
        {
            var carImage=_imageDal.Get(i=>i.CarImageId==image.CarImageId);
            var fileResult = FileHelper.Delete(carImage.ImagePath);
            if (!fileResult.Success)
            {
                return fileResult;
            }
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitCorrect(int carId)
        {
            var result = _imageDal.GetAll(i => i.CarId == carId).Count();
            if (result >= 5)
            {
                return new ErrorResult(Messages.CantAddMoreThanFiveImage);
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            var result = _imageDal.GetAll(i => i.CarId == carId);
            if (result.Count == 0)
            {
                var path = @"\Images\logo.png";
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            }

            return result;
        }
    }
}
