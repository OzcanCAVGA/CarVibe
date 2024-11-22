using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilis.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.Added);


        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var result = CheckIfBrandExists(car);

            if (!result.Success)
            {
                return result;
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Car car)
        {

            var result = CheckIfBrandExists(car);

            if (!result.Success)
            {
                return result;
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var currentTime = DateTime.Now.Hour;
            if (currentTime == 01)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            var cars = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(cars, Messages.Listed);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var cars = _carDal.GetAll(b => b.ID == brandId);

            if (cars == null || !cars.Any())
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Car>>(cars, Messages.Listed);
        }
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {

            var cars = _carDal.GetAll(c => c.ID == colorId);

            if (cars == null || !cars.Any())
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Car>>(cars, Messages.Listed);

        }

        public IDataResult<Car> GetCarById(int id)
        {
            var car = _carDal.Get(b => b.ID == id);
            if (car == null)
            {
                return new ErrorDataResult<Car>(Messages.NotFound);
            }
            return new SuccessDataResult<Car>(car, Messages.Listed);

        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var carDetails = _carDal.GetCarDetails();

            if (carDetails == null || !carDetails.Any())
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.Listed);
        }

        private IResult CheckIfBrandExists(Car car)
        {
            if (car == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return new SuccessResult();
        }
    }
}
