using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.ValidationRules
{
    public static class RentalValidator
    {
        public static bool IsCarAvailable(IRentalDal rentalDal, Rental rental)
        {
            var rentdalCount = rentalDal.GetRentalDetails(r => r.CarId == rental.CarId).Count;
            return rental.ReturnDate == null && rentalDal.GetRentalDetails(r => r.CarId == rental.CarId).Count > 0;
        }
    }
}
