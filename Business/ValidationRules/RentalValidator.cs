using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.ValidationRules
{
    public static class RentalValidator
    {
        public static bool IsCarAvailable(IRentalDal rentalDal, Rental rental)
        {
            return rentalDal.GetRentalDetails(r => r.CarId == rental.CarId).All(item => item.ReturnDate != null);
        }
    }
}
