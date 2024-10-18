using Core.Utilis.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public IResult AddCustomer(Customer customer);
        public IResult UpdateCustomer(Customer customer);
        public IResult DeleteCustomer(Customer customer);
        public IDataResult<List<Customer>> GetAllCustomers();
        public IDataResult<Customer> GetCustomerById(int id);
    }
}
