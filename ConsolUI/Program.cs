using DataAccess.Concrete.InMemory;
using Business.Concrete;
using System;
using Entities.Concrete;
using DataAccess.Concrete.EntityFrameworkk;
using Core.Utilis.Results;

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

            //AddColor("mavi",2);
            TestColors();
            //ColorUpdateTest();
            //ColorDeleted(2);

            Console.WriteLine("Calisti");

        }

        private static void ColorDeleted(int id)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetColorById(id);
            if (result.Success && result.Data != null)
            {

                colorManager.DeleteColor(result.Data);
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
            var result = colorManager.GetColorById(1);
            if (result.Success && result.Data != null)
            {
                result.Data.Name = "Turkuaz";
                colorManager.UpdateColor(result.Data);
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

            var result = colorManager.GetColors();

            if (result.Success && result.Data != null)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.Name);
                    
                }
            }
            else
            {
                Console.WriteLine("burasi");
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
            var result = brandManager.GetById(1);
            if (result.Success && result.Data != null)
            {
                brandManager.Delete(result.Data);
                TestBrands();
            }
            else
            {
                Console.WriteLine("Marka bulunamadi: " + result.Message);
            }
        }

        private static void UpdateBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(1);
            if (result.Success && result.Data != null)
            {
                //  updatedBrand.ID = 5;
                result.Data.Name = "Skoda";
                brandManager.Update(result.Data);
                TestBrands();
            }
            else
            {
                Console.WriteLine("Marka guncellenemedi: " + result.Message);
            }
        }

        private static void TestBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            IDataResult<List<Brand>> brands = brandManager.GetAll();

            foreach (var brand in brands.Data)
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

            // GetAll metodu bir IDataResult<List<Car>> döndürür
            var result = carManager.GetAll();

            // Eğer işlem başarılı ise ve veri mevcutsa
            if (result.Success && result.Data != null && result.Data.Any())
            {
                // Son arabayı alıyoruz
                Car updatedCar = result.Data.Last();

                // Arabayı güncelliyoruz
                updatedCar.DailyPrice = 1000;
                updatedCar.Description = "Guncellendi";

                carManager.Update(updatedCar);
                Console.WriteLine("Araba başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Araba bulunamadı ya da güncelleme işlemi başarısız.");
            }
        }


        private static void CarDelete(int carID)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarById(carID);
            if (result.Success && result.Data != null)
            {
                carManager.Delete(result.Data);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();
            if (result.Success == true && result.Data != null)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car ID: " + car.ID + " Brand ID: " + car.BrandID + " Color ID: " + car.ColorID + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
                }
            }
            else
            {
                Console.WriteLine("Araba listelenemedi: " + result
                    .Message);
            }

        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car { ID = 5, BrandID = 2, ColorID = 2, ModelYear = "2025", DailyPrice = 2500, Description = "Corolla 2025" };

            carManager.Add(car1);
        }
    }
}