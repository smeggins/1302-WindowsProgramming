using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorations.Reflection.ExampleImplementaion
{
    class StartupHelper
    {
        public static object GetObject(Type objectType) 
        {
            return Activator.CreateInstance(objectType);
        }
    }
}
