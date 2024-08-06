using DataAccess.Concrete.InMemory;
using Business.Concrete;
using System;
using Entities.Concrete;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach(var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID: " + car.ID + " Brand ID: " + car.BrandID + " Color ID: " + car.ColorID + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }

        }
    }
}