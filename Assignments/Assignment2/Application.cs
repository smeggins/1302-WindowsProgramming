using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Application
{
    static void Main(string[] args)
    {
        Console.WriteLine($"testBuilderPassedTest: {CarTest.testBuilder(new Logger())}");
    }
}
