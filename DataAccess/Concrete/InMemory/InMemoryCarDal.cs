using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
               new Car{ID=1, BrandID=1, ColorID=1, ModelYear="2022", DailyPrice=550, Description="Audi A4"},
               new Car{ID=2, BrandID=2, ColorID=2, ModelYear="2023", DailyPrice=620, Description="BMW X5"},
               new Car{ID=3, BrandID=3, ColorID=3, ModelYear="2021", DailyPrice=750, Description="Mercedes GLA"},
               new Car{ID=4, BrandID=4, ColorID=4, ModelYear="2022", DailyPrice=830, Description="Renault Clio"},
               new Car{ID=5, BrandID=5, ColorID=5, ModelYear="2023", DailyPrice=910, Description="Fiat 500"}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.ID == car.ID);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByID(int ID)
        {
            return _cars.Where(c => c.ID == ID).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.ID == car.ID);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
