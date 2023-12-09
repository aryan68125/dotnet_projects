namespace Aditya{
    class get_user_input{
        public static void Main(string[] args){
            //taking user input as a string
            Console.WriteLine("Enter your name");
            var x = Console.ReadLine();
            Console.WriteLine($"Hello {x} what's up");

            //How to convert a string into a number
            var a = Convert.ToInt64(Console.ReadLine());
            var b = Convert.ToInt64(Console.ReadLine());
            var c = a+b;
            Console.WriteLine($"sum  = {c}");
        }
    }
}