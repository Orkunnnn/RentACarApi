using Entities.Concrete;

namespace Business.ValidationRules
{
    public static class RentalValidator
    {
        public static bool IsCarAvailable(Rental rental)
        {
            return rental.ReturnDate != null;
        }
    }
}
