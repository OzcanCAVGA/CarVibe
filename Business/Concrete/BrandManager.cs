using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilis.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            var result = CheckIfBrandExists(brand);
            if (!result.Success)
            {
                return result;
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {

            var result = CheckIfBrandExists(brand);
            if (!result.Success)
            {
                return result;
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);

        }
        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var brand = _brandDal.Get(b => b.ID == id);
            if (brand == null)
            {
                return new ErrorDataResult<Brand>(Messages.NotFound);
            }
            return new SuccessDataResult<Brand>(brand, Messages.Listed);

        }

        private IResult CheckIfBrandExists(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return new SuccessResult();
        }
    }
}
