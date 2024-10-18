using Business.Abstract;
using Business.Constants;
using Core.Utilis.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkk;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<User> GetUserById(int id)
        {
            if (_userDal.Get(u => u.ID == id) == null)
            {
                return new ErrorDataResult<User>(Messages.NotFound);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.ID == id));
        }

        public IResult UpdateUser(User user)
        {
            if (user == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
