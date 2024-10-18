using Business.Abstract;
using Business.Constants;
using Core.Utilis.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkk;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult AddRental(Rental rental)
        {
            bool isCarAvaible = !(_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Any());
            if (isCarAvaible == true)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarIsNotAvaible);
            }
        }

        public IResult DeleteRental(Rental rental)
        {
            if (rental == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }


        public IDataResult<List<Rental>> GetAllRental()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            if (_rentalDal.Get(b => b.ID == id) == null)
            {
                return new ErrorDataResult<Rental>(Messages.NotFound);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.ID == id));
        }

        public IResult ReturnCar(Rental rental)
        {
            if(rental == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _rentalDal.ReturnCar(rental);
            return new SuccessResult(Messages.ReturnCar);
        }

        public IResult UpdateRental(Rental rental)
        {
            if (rental == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
