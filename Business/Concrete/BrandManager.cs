using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);


        }

        public IResult Delete(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Brand brand)
        {
            if (brand == null)
            {
                return new ErrorResult(Messages.NotFound);
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
            if (_brandDal.Get(b => b.ID == id) == null)
            {
                return new ErrorDataResult<Brand>(Messages.NotFound);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.ID == id), Messages.Listed);

        }


    }
}
