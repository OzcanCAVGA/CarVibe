using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilis.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {
            Console.WriteLine("Success result 1.constructor calisti");
        }
        public SuccessResult() : base(true)
        {
            Console.WriteLine("Success result 2.constructor calisti");
        }
    }
}
