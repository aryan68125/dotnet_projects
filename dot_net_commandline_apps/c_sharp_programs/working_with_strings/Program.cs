namespace Aditya{
    class Strings_working{
        public static void Main(string[] args){
            string name = "Rollex";
            var college_name = "SITM";
            string Addr  = "2/446 sec-L LDA colony";
            var city = "lucknow";
            Console.WriteLine($"name : {name}, college_name : {college_name}, Address : {Addr} city: {city}");
            //number of character in a string
            Console.WriteLine($"name : {name.Length} college_name : {college_name.Length} Address : {Addr.Length} city: {city}");
        }
    }
}