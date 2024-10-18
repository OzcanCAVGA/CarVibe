using Business.Abstract;
using Business.Constants;
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

        public IResult AddCustomer(Customer customer)
        {
            if (customer.CompanyName.Length >= 2)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }


        public IResult DeleteCustomer(Customer customer)
        {
            if (customer == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            if (_customerDal.Get(b => b.ID == id) == null)
            {
                return new ErrorDataResult<Customer>(Messages.NotFound);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(b => b.ID == id));
        }

        public IResult UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
