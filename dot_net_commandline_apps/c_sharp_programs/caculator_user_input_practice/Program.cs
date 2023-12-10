namespace Aditya{
    class Calculator_practice{
        public static void Main(string[] args){
            for(int i=0;i>-1;i++){
                Console.WriteLine("Enter first number");
                decimal num1=Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter second number");
                decimal num2=Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Press + for addition");
                Console.WriteLine("Press - for subtraction");
                Console.WriteLine("Press * for multiplication");
                Console.WriteLine("Press / for division");
                Console.WriteLine("Press q for shutting down the caluclator");
                var ch = Console.ReadLine();
                decimal result;
                try{
                if(ch == "+"){
                    result = Sum(num1,num2);
                    Console.WriteLine($"{num1} + {num2} = {result}");
                }
                else if(ch == "-"){
                    result = Sub(num1,num2);
                    Console.WriteLine($"{num1} - {num2} = {result}");
                }
                else if(ch == "*"){
                    result = Mul(num1,num2);
                    Console.WriteLine($"{num1} * {num2} = {result}");
                }
                else if(ch == "/"){
                    result = Div(num1,num2);
                    Console.WriteLine($"{num1} / {num2} = {result}");
                }
                else if(ch == "q"){
                    Console.WriteLine("Shutting down calculator");
                    Console.WriteLine("Reached target location shutdown system tree processes");
                    break;
                }
                else{
                    Console.WriteLine("Wrong choice entered please try again");
                }
                }
                catch(Exception e)
                {
                    //pass
                }
            }
        }
        public static decimal Sum(decimal num1, decimal num2){
            return num1+num2;
        }
        public static decimal Sub(decimal num1, decimal num2){
            return num1-num2;
        }
        public static decimal Mul(decimal num1, decimal num2){
            return num1*num2;
        }
        public static decimal Div(decimal num1, decimal num2){
            if(num2==0){
                Console.WriteLine("Divide by zero error");
                return 0;
            }
            else{
                return num1/num2;
            }
        }
    }
}