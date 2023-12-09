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

            //string methods
            /*
            ToUpper() //converts the string into uppercase
            ToLower() //converts the string into lowercase
            Contains("parameter_string") //we use this if a sentence or a word contains the word passed as a parameter
            How to find the first character in a string
            string_variable_name[0] ==> accessing first character in a string
            */
            Console.WriteLine(city.ToUpper());
            Console.WriteLine(college_name.ToLower());
            Console.WriteLine(Addr.Contains("colony"));
            Console.WriteLine(name[0]);
            Console.WriteLine(Addr.IndexOf("colony"));
            Console.WriteLine(Addr.IndexOf("c"));
            Console.WriteLine(Addr.Substring(16));
            Console.WriteLine(Addr.Substring(16,3));
            Console.WriteLine(name.Equals(college_name));
        }
    }
}