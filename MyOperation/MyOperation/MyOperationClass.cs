using MyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOperation
{
    public class ExCalculator2 : ICalculator
    {
        public void Evaluate(string operation, int a, int b)
        {
            Console.WriteLine("Ok!");
        }
    }

    public class MyOperationClass
    {
        public string MakeOperation()
        {
            return "Done!";
        }
    }

    public class MyOperationClass2
    {
        public string MakeOperation()
        {
            return "Done2!";
        }
    }
}
