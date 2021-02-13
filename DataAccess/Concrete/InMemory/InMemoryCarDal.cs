using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private readonly List<Car> _cars = new List<Car>
        {
            new Car
            {
                CarId = 1,
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 500,
                Description = "Volkswagen",
                ModelYear = 2005
            },
            new Car
            {
                CarId = 2,
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 1000,
                Description = "Mercedes",
                ModelYear = 2008
            },
            new Car
            {
                CarId = 3,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 800,
                Description = "Toyota",
                ModelYear = 2012
            },
            new Car
            {
                CarId = 4,
                BrandId = 1,
                ColorId = 5,
                DailyPrice = 600,
                Description = "Fiat",
                ModelYear = 2015
            },
        };

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            if (carToUpdate == null) return;
            car.Description = carToUpdate.Description;
            car.BrandId = carToUpdate.BrandId;
            car.ColorId = carToUpdate.ColorId;
            car.DailyPrice = carToUpdate.DailyPrice;
            car.ModelYear = carToUpdate.ModelYear;
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }
    }
}
