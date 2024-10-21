using DataAccess.Concrete.InMemory;
using Business.Concrete;
using System;
using Entities.Concrete;
using DataAccess.Concrete.EntityFrameworkk;
using Core.Utilis.Results;
using Business.Constants;

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
            //TestColors();
            //ColorUpdateTest();
            //ColorDeleted(2);

            //Console.WriteLine("Calisti");


            //AddUser();
            //TestUsers();
            //UpdateUser();
            //DeleteUser();

            //AddCustomer();
            //TestCustomers();
            //UpdateCustomer();
            //DeleteCustomer();

            //AddRental();
            //ReturnCar();



        }

        private static void ReturnCar()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var returnRental = rentalManager.GetRentalById(6);
            rentalManager.ReturnCar(returnRental.Data);
        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental = new Rental() { CarId = 2, CustomerId = 2, RentDate = DateTime.Now };
            rentalManager.AddRental(rental);
        }

        private static void DeleteCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetCustomerById(2);
            if (result.Success && result.Data != null)
            {

                customerManager.DeleteCustomer(result.Data);
                Console.WriteLine(Messages.Deleted);
                TestCustomers();
            }
            else
            {
                Console.WriteLine(Messages.NotFound);
            }
        }

        private static void UpdateCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerById(2);
            if (result.Success && result.Data != null)
            {
                result.Data.CompanyName = "Volvo";
                customerManager.UpdateCustomer(result.Data);
                TestCustomers();
            }
            else
            {
                Console.WriteLine(Messages.NotFound);
            }
        }

        private static void TestCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            IDataResult<List<Customer>> customers = customerManager.GetAllCustomers();

            foreach (var customer in customers.Data)
            {
                Console.WriteLine(customer.ID + " UserId: " + customer.UserId + " " + customer.CompanyName);
            }
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer() { UserId = 2, CompanyName = "BMW" };
            customerManager.AddCustomer(customer);
        }

        private static void DeleteUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetUserById(4);
            if (result.Success && result.Data != null)
            {

                userManager.DeleteUser(result.Data);
                Console.WriteLine(Messages.Deleted);
                TestUsers();
            }
            else
            {
                Console.WriteLine("Renk bulunamadi");
            }
        }

        private static void UpdateUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetUserById(2);
            if (result.Success && result.Data != null)
            {
                result.Data.FirstName = "Fatih Isa";
                userManager.UpdateUser(result.Data);
                TestUsers();
            }
            else
            {
                Console.WriteLine(Messages.NotFound);
            }
        }

        private static void TestUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            IDataResult<List<User>> users = userManager.GetAllUsers();

            foreach (var user in users.Data)
            {
                Console.WriteLine(user.ID + " " + user.FirstName + " " + user.LastName);
            }
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User() { FirstName = "Silinecek", LastName = "Kayit", Email = "delete@gmail.com", Password = "123456" };
            userManager.AddUser(user);
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


        //private static void CarDelete(int carID)
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var result = carManager.GetCarById(carID);
        //    if (result.Success && result.Data != null)
        //    {
        //        carManager.Delete(result);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }

        //}

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