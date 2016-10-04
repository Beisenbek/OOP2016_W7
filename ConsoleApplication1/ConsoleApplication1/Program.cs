using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface ICalculator
    {
        void Evaluate(string operation, int a, int b);
        void SetupContainer(UnityContainer container);
    }

    abstract class BaseCalculator : ICalculator
    {
        protected UnityContainer container;
        public virtual void Evaluate(string op, int a, int b)
        {
            IOperation operation = container.Resolve<IOperation>(op);
            Console.WriteLine(operation.Invoke(a, b));
           
        }
        public void SetupContainer(UnityContainer container)
        {
            this.container = container;
        }
    }

    class ExCalculator : BaseCalculator
    {
        public override void Evaluate(string op, int a, int b)
        {
            base.Evaluate(op, a, b);
            Console.WriteLine("Extended");
        }
    }

    interface IOperation
    {
        string Invoke(int a, int b);
    }

    class Calculator : BaseCalculator
    {

    }

    class OperationPlus : IOperation
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
        public static void Setup(UnityContainer container)
        {
            container.RegisterType<IOperation, OperationPlus>("+");
            container.RegisterType<IOperation, OperationMinus>("-");
            container.RegisterType<ICalculator, Calculator>("simple");
            container.RegisterType<ICalculator, ExCalculator>("ex");
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

            using (UnityContainer container = new UnityContainer())
            {
                Factory.Setup(container);
                ICalculator calc = container.Resolve<ICalculator>(calculatorType);
                calc.SetupContainer(container);
                calc.Evaluate(operation, a, b);
            }
        }
    }
}
