using Business.Abstract;
using Business.Constants;
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
        public IResult AddColor(Color color)
        {
            if (color.Name.Length >= 2)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }

        public IResult DeleteColor(Color color)
        {
            if (color == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult UpdateColor(Color color)
        {
            if (color == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Color>> GetColors()
        {
            if (_colorDal.GetAll() == null)
            {
                return new ErrorDataResult<List<Color>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetColorById(int id)
        {
            if (_colorDal.GetAll(b => b.ID == id) == null)
            {
                return new ErrorDataResult<Color>(Messages.NotFound);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(b => b.ID == id));
        }


    }
}
