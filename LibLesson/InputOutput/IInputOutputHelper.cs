using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLesson.InputOutput
{
    public interface IInputOutputHelper
    {
        T InputSingleValue<T>(string message);
        void Output(string message);
    }
}
