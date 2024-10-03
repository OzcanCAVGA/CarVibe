using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess.Concrete.EntityFrameworkk
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandID equals b.ID

                             join color in context.Colors
                             on c.ColorID equals color.ID
                             select new CarDetailDto
                             {

                                 CarName = c.Description,
                                 BrandName = b.Name,
                                 ColorName = color.Name,
                                 DailyPrice = c.DailyPrice,
                             };
                return result.ToList();

            }
        }
    }
}
