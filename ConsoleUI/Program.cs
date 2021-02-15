using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //var rentalService = new RentalManager(new EfRentalDal());
            //var result = rentalService.Add(new Rental
            //{
            //    CarId = 3,
            //    CustomerId = 1,
            //    RentDate = DateTime.Now,
            //    ReturnDate = null
            //});
            //Console.WriteLine(result.Message);
            var rentalService = new RentalManager(new EfRentalDal());
            var result = rentalService.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.Now
            });
            Console.WriteLine(result.Message);
        }

        private static void CarTest()
        {
            var carService = new CarManager(new EfCarDal());
            carService.GetCarDetails().Data.ForEach(c =>
            {
                Console.WriteLine("{0} {1} {2}", c.CarName, c.BrandName, c.ColorName);
            });
        }
    }
}
