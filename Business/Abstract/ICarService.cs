using Core.Utilis.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        public IResult Add(Car car);
        public IResult Update(Car car);
        public IResult Delete(Car car);

        public IDataResult<Car> GetCarById(int id);
        public IDataResult<List<Car>> GetCars();
        public IDataResult<List<CarDetailDto>> GetCarDetails();

        public IDataResult<List<Car>> GetAll();
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        public IDataResult<List<Car>> GetCarsByColorId(int colorId);
    }
}
