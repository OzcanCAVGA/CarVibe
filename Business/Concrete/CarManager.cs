using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkk;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır ve günlük fiyatı 0'dan büyük olmalıdır.");
            }
        }

        public List<Car> GetAll()
        {
            // is kodlari
            // Yetkisi var mi?
            // vs vs
            return _carDal.GetAll();
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {

            return _carDal.GetAll(c => c.BrandID == brandId);
        }
        public List<Car> GetCarsByColorId(int colorId)
        {

            return _carDal.GetAll(c => c.ColorID == colorId);

        }
    }
}
