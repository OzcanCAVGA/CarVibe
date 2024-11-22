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
        [ValidationAspect(typeof(UserValidator))]
        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteUser(User user)
        {
            var result = CheckIfUserExists(user);
            if (!result.Success)
            {
                return result;
            }

            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            var users = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(users, Messages.Listed);
        }

        public IDataResult<User> GetUserById(int id)
        {
            var user = _userDal.Get(u => u.ID == id);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.NotFound);
            }
            return new SuccessDataResult<User>(user);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult UpdateUser(User user)
        {
            var result = CheckIfUserExists(user);
            if (!result.Success)
            {
                return result;
            }

            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfUserExists(User user)
        {
            if (user == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return new SuccessResult();
        }
    }
}
