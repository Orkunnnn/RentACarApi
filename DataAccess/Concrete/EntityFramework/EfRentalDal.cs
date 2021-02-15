using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using var context = new ReCapContext();
            var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                join c in context.Cars
                    on r.CarId equals c.CarId
                join cu in context.Customers
                    on r.CustomerId equals cu.CustomerId
                join b in context.Brands
                    on c.BrandId equals b.BrandId
                join u in context.Users
                    on cu.UserId equals u.UserId
                select new RentalDetailsDto
                {
                    RentalId = r.RentalId,
                    CarName = b.BrandName,
                    CompanyName = cu.CompanyName,
                    UserName = string.Concat(u.FirstName," ",u.LastName),
                    RentDate = r.RentDate,
                    ReturnDate = r.ReturnDate
                };
            return result.ToList();
        }

        
    }
}
