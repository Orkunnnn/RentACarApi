using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var carService = new CarManager(new InMemoryCarDal());
            var carList = carService.GetAll();
            carList.ForEach(c =>
            {
                Console.WriteLine(c.Description);
            });
        }
    }
}
