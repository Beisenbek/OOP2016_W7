using MyInterfaces;
using MyOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityIOCSample
{
    class ExCalculator: ICalculator
    {
        public void Evaluate(string operation, int a, int b)
        {
        }
    }

    interface IOperation
    {
        string Invoke(int a, int b);
    }

    class Calculator:ICalculator
    {
        public void Evaluate(string operation, int a, int b)
        {
            if (operation.Equals("+"))
            {
                OperationPlus op = new OperationPlus();
                Console.WriteLine(op.Invoke(a, b));
            }
            else if (operation.Equals("-"))
            {
                OperationMinus op = new OperationMinus();
                Console.WriteLine(op.Invoke(a, b));
            }
        }
    }

    class OperationPlus:IOperation
    {
        public string Invoke(int a, int b)
        {
            return (a + b).ToString();
        }
    }

    class OperationMinus : IOperation
    {
        public string Invoke(int a, int b)
        {
            return (a - b).ToString();
        }
    }

    class Factory
    {
        public static ICalculator GetCalculator(string calculatorType)
        {
            ICalculator res;
            if (calculatorType.Equals("ex"))
            {
                res = new ExCalculator();
            }else
            if (calculatorType.Equals("ex2"))
            {
                res = new ExCalculator2();
            }
            else
            {
                res = new Calculator();
            }

            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            string calculatorType = Console.ReadLine();

            ICalculator calc = Factory.GetCalculator(calculatorType);
            calc.Evaluate(operation, a, b);

        }
    }
}
