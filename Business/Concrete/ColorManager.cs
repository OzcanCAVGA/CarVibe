using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilis.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult AddColor(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteColor(Color color)
        {
            var result = CheckIfColorExists(color);
            if (!result.Success)
            {
                return result;
            }

            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult UpdateColor(Color color)
        {
            var result = CheckIfColorExists(color);
            if (!result.Success)
            {
                return result;
            }


            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Color>> GetColors()
        {
            var colors = _colorDal.GetAll();
            if (colors.Count == 0)
            {
                return new ErrorDataResult<List<Color>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Color>>(colors);
        }

        public IDataResult<Color> GetColorById(int id)
        {

            var color = _colorDal.Get(b => b.ID == id);
            if (color == null)
            {
                return new ErrorDataResult<Color>(Messages.NotFound);
            }

            return new SuccessDataResult<Color>(color);
        }

        private IResult CheckIfColorExists(Color color)
        {
            if (color == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return new SuccessResult();
        }

    }
}
