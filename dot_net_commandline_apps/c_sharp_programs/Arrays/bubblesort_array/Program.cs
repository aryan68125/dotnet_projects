namespace Aditya{
    class BubbleSort{
        public static void Main(string[] args){
            Console.WriteLine("BubbleSort Program Arrays");
            for(int i=0;i<1000;i++){
                Console.WriteLine("Enter the size of the array");
                int size = Convert.ToInt32(Console.ReadLine());
                int[] arr=new int[size];
                //enter array elements
                Console.WriteLine("Enter elements in the array");
                EnterElements(arr, size);
                //print the entered array elements by the user
                Console.WriteLine("Display the elements of the array");
                DisplayArray(arr, size);
                //performing bubblesort
                Console.WriteLine("Performing bubblesort ascending order");
                BubbleSort_function(arr,size);
                Console.WriteLine("Display array after bubblesort operation");
                DisplayArray(arr,size);

                Console.WriteLine("Do you want to continue y/n");                
                string ch=Console.ReadLine();

                if(ch=="n"){
                    Console.WriteLine("exit bubblesort program");
                    Console.WriteLine("Reached target location shutting down program");
                    break;
                }
            }
        }
        public static void EnterElements(int[] arr, int size){
            for (int i=0;i<size;i++){
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static void DisplayArray(int[] arr, int size){
            for(int i=0;i<size;i++){
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("");
        }
        public static void BubbleSort_function(int[] arr, int size){
            for(int i=0;i<size-1;i++){
                for(int j=i+1;j<size;j++){
                    if(arr[i]>arr[j]){
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}