using System;
using Entities.Concrete;

namespace Business.ValidationRules
{
    public static class CarValidator
    {
        public static bool IsCarValid(Car car)
        {
            return car.Description.Length >= 2 && car.DailyPrice >= 0;
        }
    }
}
