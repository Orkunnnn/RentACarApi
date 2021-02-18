using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Linq;

namespace Business.ValidationRules
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        private readonly IRentalDal _rentalDal;
        public RentalValidator(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
            RuleFor(r => r).Must(CarAvailable).WithMessage("Araba kiralanamaz.");
        }

        public bool CarAvailable(Rental rental)
        {
            return _rentalDal.GetRentalDetails(r => r.CarId == rental.CarId).All(item => item.ReturnDate != null);
        }

    }
}
