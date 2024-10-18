using Core.DataAccess.EntityFramework;
using Core.Utilis.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFrameworkk
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {
        public List<Rental> GetRentedCarById(int id)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                return context.Rentals
                    .Where(r => r.CarId == id)
                    .ToList();
            }
        }

        public void ReturnCar(Rental rental)
        {
            using(ReCapDbContext context = new ReCapDbContext())
            {
                var query = context.Rentals.Where(r=> (r.ID == rental.ID) && r.ReturnDate == null);
                if (query.Any())
                {
                    rental.ReturnDate = DateTime.Now;
                    var returnCar = context.Entry(rental);
                    returnCar.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}
