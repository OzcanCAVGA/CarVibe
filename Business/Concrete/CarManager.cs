using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Car car) 
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }
        public IResult Update(Car car) 
        {
            if (car == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
        public IResult Delete(IDataResult<Car> car) 
        {
       
            if (car == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _carDal.Delete(car.Data);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll() 
        {
            if (DateTime.Now.Hour == 01)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId) 
        {

            if (_carDal.Get(b => b.ID == brandId) == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandID == brandId));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int colorId) 
        {
            if (_carDal.Get(b => b.ID == colorId) == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorID == colorId));

        }

        public IDataResult<Car> GetCarById(int id) 
        {
            if (_carDal.Get(b => b.ID == id) == null)
            {
                return new ErrorDataResult<Car>(Messages.NotFound);
            }
            return new SuccessDataResult<Car>(_carDal.Get(b => b.ID == id));

        }


        public IDataResult<List<CarDetailDto>> GetCarDetails() 
        {
            if (_carDal.GetAll() == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }


    }
}
