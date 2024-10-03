using Core.Utilis.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        public IResult AddColor(Color color);
        public IResult DeleteColor(Color color);
        public IResult UpdateColor(Color color);
        public IDataResult<List<Color>> GetColors();

        public IDataResult<Color> GetColorById(int id);
    }
}
