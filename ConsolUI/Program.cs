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
            // AddCar();
            //CarTest();
            // CarUpdateTest();
            //CarDelete(1);

            //AddBrand();
            //TestBrands();
            //UpdateBrand();
            // DeleteBrand();

            //AddColor(mavi,2);
            //TestColors();
            //ColorUpdateTest();
            //ColorDeleted(1);

            Console.WriteLine("Calisti");

        }

        private static void ColorDeleted(int id)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color deletedColor = colorManager.GetColourById(id);
            if (deletedColor != null)
            {
                colorManager.DeleteColor(deletedColor);
                Console.WriteLine("Islem basariyla gerceklestirildi");
                TestColors();
            }
            else
            {
                Console.WriteLine("Renk bulunamadi");
            }
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color updatedColor = colorManager.GetColourById(1);
            if (updatedColor != null)
            {
                updatedColor.Name = "Turkuaz";
                colorManager.UpdateColor(updatedColor);
                TestColors();
            }
            else
            {
                Console.WriteLine("Renk bulunamadi");
            }
        }

        private static void TestColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetColors())
            {
                Console.WriteLine(color.Name + " adinda renk var");
            }
        }

        private static void AddColor(string renk, int id)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color { ID = id, Name = renk };
            colorManager.AddColor(color1);
        }

        private static void DeleteBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand deletedBrand = brandManager.GetById(1);
            if (deletedBrand != null)
            {
                brandManager.Delete(deletedBrand);
                TestBrands();
            }
            else
            {
                Console.WriteLine("Marka bulunamadi");
            }
        }

        private static void UpdateBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand updatedBrand = brandManager.GetById(1);
            if (updatedBrand != null)
            {
                //  updatedBrand.ID = 5;
                updatedBrand.Name = "Skoda";
                brandManager.Update(updatedBrand);
                TestBrands();
            }
            else
            {
                Console.WriteLine("Marka bulunamadi");
            }
        }

        private static void TestBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            List<Brand> brands = brandManager.GetAll();

            foreach (Brand brand in brands)
            {
                Console.WriteLine(brand.ID + " " + brand.Name);
            }
        }

        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand2 = new Brand { ID = 1, Name = "Audi" };
            brandManager.Add(brand2);
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car updatedCar = carManager.GetAll().Last();
            if (updatedCar != null)
            {
                updatedCar.DailyPrice = 1000;
                updatedCar.Description = "Guncellendi";

                carManager.Update(updatedCar);
            }
            else
            {
                Console.WriteLine("Arac bulunamadi");
            }
        }

        private static void CarDelete(int carID)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(carManager.GetCarById(carID));
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID: " + car.ID + " Brand ID: " + car.BrandID + " Color ID: " + car.ColorID + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car { ID = 2, BrandID = 2, ColorID = 2, ModelYear = "2022", DailyPrice = 1500, Description = "BMW 2025" };

            carManager.Add(car1);
        }
    }
}