using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using var context = new ReCapContext();
            var result = from car in context.Cars
                join b in context.Brands on car.BrandId equals b.BrandId
                join col in context.Colors on car.ColorId equals col.ColorId
                select new CarDetailsDto
                {
                    CarName = car.Description, DailyPrice = car.DailyPrice, BrandName = b.BrandName,
                    ColorName = col.ColorName
                };
            return result.ToList();
        }
    }
}
