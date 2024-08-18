using DataAccess.Concrete.InMemory;
using Business.Concrete;
using System;
using Entities.Concrete;
using DataAccess.Concrete.EntityFrameworkk;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { ID = 1, BrandID = 1, ColorID = 1, ModelYear = "2021", DailyPrice = 500, Description = "Audi A3" };
            
            carManager.Add(car1);


            foreach(var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID: " + car.ID + " Brand ID: " + car.BrandID + " Color ID: " + car.ColorID + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }

        }
    }
}