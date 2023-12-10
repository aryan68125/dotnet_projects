namespace Aditya
{
    class Array_Basics{
        public static void Main(string[] args){
            Console.WriteLine("Array Basics");
            Console.WriteLine("Enter the size of the integer array");
            int size = Convert.ToInt32(Console.ReadLine());
            int [] arr=new int[size];
            Console.WriteLine("Enter elements in the array");
            for(int i=0;i<arr.Length;i++){
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Display array Elements");
            for(int i=0;i<arr.Length;i++){
                Console.WriteLine(arr[i]);
            }
        }
    }
}