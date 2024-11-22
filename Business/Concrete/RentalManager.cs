using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
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

        [ValidationAspect(typeof(RentalValidator))]
        public IResult AddRental(Rental rental)
        {
            bool isCarAvaible = (_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Count == 0);
            if (!isCarAvaible)
            {
                return new ErrorResult(Messages.CarIsNotAvaible);

            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult DeleteRental(Rental rental)
        {

            var result = CheckIfRentalExists(rental);
            if (!result.Success)
            {
                return result;
            }

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }


        public IDataResult<List<Rental>> GetAllRental()
        {
            var rentals = _rentalDal.GetAll();

            return new SuccessDataResult<List<Rental>>(rentals, Messages.Listed);
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            var car = _rentalDal.Get(b => b.ID == id);
            if (car == null)
            {
                return new ErrorDataResult<Rental>(Messages.NotFound);
            }
            return new SuccessDataResult<Rental>(car);
        }

        public IResult ReturnCar(Rental rental)
        {
            var result = CheckIfRentalExists(rental);
            if (!result.Success)
            {
                return result;
            }
            _rentalDal.ReturnCar(rental);
            return new SuccessResult(Messages.ReturnCar);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult UpdateRental(Rental rental)
        {
            var result = CheckIfRentalExists(rental);

            if (!result.Success)
            {
                return result;
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckIfRentalExists(Rental rental)
        {

            if (rental == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return new SuccessResult();
        }
    }
}
