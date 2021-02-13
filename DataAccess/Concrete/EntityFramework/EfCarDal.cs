using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using var context = new ReCapContext();
            return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using var context = new ReCapContext();
            return context.Set<Car>().SingleOrDefault(filter);
        }

        public Car GetById(int id)
        {
            using var context = new ReCapContext();
            return context.Set<Car>().SingleOrDefault(c => c.CarId == id);
        }

        public void Add(Car entity)
        {
            using var context = new ReCapContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
            context.SaveChanges();
        }

        public void Update(Car entity)
        {
            using var context = new ReCapContext();
            var modifiedEntity = context.Entry(entity);
            modifiedEntity.State = EntityState.Modified;
            context.SaveChanges();
            context.SaveChanges();
        }

        public void Delete(Car entity)
        {
            using var context = new ReCapContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
