namespace Aditya{
    class SelectionSort{
        public static void Main(string[] args){
            Console.WriteLine("SelectionSort program arrays");
            for(int i=0;i<1000;i++){
                Console.WriteLine("Enter the size of the array");
                int size = Convert.ToInt32(Console.ReadLine());
                int[] arr=new int[size];

                //enter array elements
                Console.WriteLine("Enter array elements");
                EnterElements(arr,size);

                //Display Array elements
                Console.WriteLine("Display array elements");
                DisplayArray(arr,size);

                //Display array after performing selection_sort
                Console.WriteLine("Performing selection sort on array");
                SelectionSort_function(arr,size);
                Console.WriteLine("Display array after selection sort is performed");
                DisplayArray(arr,size);

                Console.WriteLine("Do you want to continue y/n");
                string ch = Console.ReadLine();
                if(ch=="n"){
                    Console.WriteLine("Reached target location exiting program now");
                    break;
                }
            }
        }
        public static void EnterElements(int[] arr,int size){
            for(int i=0;i<size;i++){
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static void DisplayArray(int[] arr, int size){
            for(int i=0;i<size;i++){
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("");
        }
        public static void SelectionSort_function(int[] arr, int size){
            for(int i=0;i<size-1;i++){
                int minIndex=i;
                for(int j=i+1;j<size;j++){
                    if(arr[j]<arr[minIndex]){
                        minIndex=j;
                    }
                }

                //swap elements in array
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }
}