using Core.Utilis.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IResult AddUser(User user);
        public IResult UpdateUser(User user);
        public IResult DeleteUser(User user);
        public IDataResult<List<User>> GetAllUsers();
        public IDataResult<User> GetUserById(int id);

    }
}
