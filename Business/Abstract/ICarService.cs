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
        public void Add(Car car);
        public void Update(Car car);
        public void Delete(Car car);

        Car GetCarById(int id);
        List<Car> GetCars();
        List<CarDetailDto> GetCarDetails();

        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
    }
}
