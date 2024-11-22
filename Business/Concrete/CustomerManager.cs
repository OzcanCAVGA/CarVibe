using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilis.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkk;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }


        public IResult DeleteCustomer(Customer customer)
        {
            var result = CheckIfCustomerExists(customer);
            if (!result.Success)
            {
                return result;
            }

            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        {

            var currentTime = DateTime.Now.Hour;
            if (currentTime == 01)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }

            var customers = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(customers, Messages.Listed);
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerDal.Get(b => b.ID == id);
            if (customer == null)
            {
                return new ErrorDataResult<Customer>(Messages.NotFound);
            }
            return new SuccessDataResult<Customer>(customer, Messages.Listed);
        }

        public IResult UpdateCustomer(Customer customer)
        {
            var result = CheckIfCustomerExists(customer);
            if (!result.Success)
            {
                return result;
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckIfCustomerExists(Customer customer)
        {
            if (customer == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return new SuccessResult();
        }
    }
}
