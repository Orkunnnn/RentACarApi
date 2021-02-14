using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var carService = new CarManager(new EfCarDal());
            var carList = carService.GetCarDetails();
            carList.ForEach(c =>
            {
                Console.WriteLine("{0} {1} {2}",c.CarName,c.BrandName,c.ColorName);
            });
        }
    }
}
