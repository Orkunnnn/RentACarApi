using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var carService = new CarManager(new EfCarDal());
            carService.GetCarDetails().Data.ForEach(c =>
            {
                Console.WriteLine("{0} {1} {2}", c.CarName, c.BrandName, c.ColorName);
            });
        }
    }
}
