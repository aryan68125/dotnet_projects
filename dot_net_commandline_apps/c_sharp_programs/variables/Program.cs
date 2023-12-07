namespace Aditya{
    class Variables{
        public static void Main(string[] args){
            //using statically defined variables
            string sentence1 = "There is a boy named Rollex";
            int number = 20;
            double double_variable = 50000.526;
            Console.WriteLine(sentence1);
            Console.WriteLine(number);
            Console.WriteLine(double_variable);

            //using dynamically defined variables
            var sentence2 = "There is a boy named Aditya";
            var number2 = 26;
            var double_variable2 = 905621.526;
            Console.WriteLine(sentence2);
            Console.WriteLine(number2);
            Console.WriteLine(double_variable2);
        }
    }
}