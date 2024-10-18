using Core.Utilis.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        public IResult AddRental(Rental rental);
        public IResult UpdateRental(Rental rental);
        public IResult DeleteRental(Rental rental);
        public IResult ReturnCar(Rental rental);
        public IDataResult<List<Rental>> GetAllRental();
        public IDataResult<Rental> GetRentalById(int id);

    }
}
