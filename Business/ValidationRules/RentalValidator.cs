using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Linq;

namespace Business.ValidationRules
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator(IRentalDal rentalDal)
        {
            RuleFor(r => r.RentDate).NotNull();
        }
    }
}
