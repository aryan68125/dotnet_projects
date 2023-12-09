using System; // You need to include the System namespace for Console and other classes

namespace Aditya
{
    class Calculator
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Enter the first number");
                var num1 = Convert.ToDecimal(Console.ReadLine()); 
                Console.WriteLine("Enter the second number");
                var num2 = Convert.ToDecimal(Console.ReadLine()); 
                Console.WriteLine("Enter the operator +,-,*,/");
                string oper = Console.ReadLine(); 
                decimal result = 0; 
                if (oper == "+")
                {
                    result = Sum(num1, num2);
                    Console.WriteLine($"Addition : {result}");
                }
                else if (oper == "-")
                {
                    result = Subtract(num1, num2); 
                    Console.WriteLine($"Subtraction : {result}");
                }
                else if (oper == "*")
                {
                    result = Multiply(num1, num2); 
                    Console.WriteLine($"Multiply : {result}");
                }
                else if (oper == "/")
                {
                    result = Divide(num1, num2); 
                    Console.WriteLine($"Divide : {result}");
                }
                else
                {
                    Console.WriteLine("Wrong choice");
                }
                Console.WriteLine("Do you want to continue? (y/n)");
                var con = Console.ReadLine();
                if (con.ToLower() != "y") 
                {
                    break;
                }
            }
        }

        public static decimal Sum(decimal a, decimal b) 
        {
            return a + b;
        }

        public static decimal Subtract(decimal a, decimal b) 
        {
            return a - b;
        }

        public static decimal Multiply(decimal a, decimal b) 
        {
            return a * b;
        }

        public static decimal Divide(decimal a, decimal b) 
        {
            if (b == 0)
            {
                Console.WriteLine("Divide by zero error");
                return 0; 
            }
            else
            {
                return a / b;
            }
        }
    }
}
