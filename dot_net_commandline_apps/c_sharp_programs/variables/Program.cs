namespace Aditya{
    class Variables{
        public static void Main(string[] args){
            //using statically defined variables
            string sentence1 = "There is a boy named Rollex";
            int number1 = 20;
            double double_variable1 = 50000.526;
            Console.WriteLine("string : " + sentence1);
            Console.WriteLine("integer : " + number1);
            Console.WriteLine("double : " + double_variable1);

            //using dynamically defined variables
            var sentence2 = "There is a boy named Aditya";
            var number2 = 26;
            var double_variable2 = 905621.526;
            Console.WriteLine("string : " + sentence2);
            Console.WriteLine("integer : " + number2);
            Console.WriteLine("double : "  + double_variable2);
        }
    }
}