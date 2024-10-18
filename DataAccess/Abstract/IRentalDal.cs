using Core.DataAccess;
using Core.Utilis.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        void ReturnCar(Rental rental);
        List<Rental> GetRentedCarById(int id);
    }
}
