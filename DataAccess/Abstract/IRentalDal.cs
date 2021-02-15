using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
