

int[] array = { 6, 7, 8, 9, 10, 11, 12, 1, 2, 3, 4, 5 };
//search for each value in the array
foreach (int n in array)
{
    int index = RotatedSearch(array, 0, array.Length - 1, n);
    string message = index > -1 ? $" Found Key {n} it is at array index {index}" :
        $" Failed to find Key {n}";
    Console.WriteLine(message);
}
Console.ReadLine();
/*
 Sample output
[6,7,8,9,10,11,12,1,2,3,4,5]
Mid Index = 5 split on value 11 key value  is 4

 [12,1,2,3,4,5]
Mid Index = 8 split on value 2 key value  is 4

 [3,4,5]
Mid Index = 10 split on value 4 key value  is 4
 Found Key 4 it is at array index 10
*/

static int RotatedSearch(int[] arr, int low, int high, int key)
{
    int pivot = (low + high) / 2;
    PrintArray(arr, low, high, pivot, key);
    if (low > high) return -1;//out of bounds=> key not found
    if (arr[pivot] == key) return pivot;// key found
    //if left side is sorted and left side contains the key
    //OR if left side is not sorted and right side does not contain the key
    //search left ELSE search right
    return ((arr[low] <= arr[pivot]) && (arr[low] <= key && arr[pivot] > key)) ||
                             arr[low] > arr[pivot] && !(key > arr[pivot] && key <= arr[high]) ?
                             RotatedSearch(arr, low, pivot - 1, key) : RotatedSearch(arr, pivot + 1, high, key);
}

static void PrintArray(int[] arr, int start, int end, int mid, int key)
{
    var range = arr.Where((n, i) => i >= start && i <= end);
    Console.WriteLine($"\r\n [{string.Join(',', range)}] ");
    Console.WriteLine($" Mid Index={mid} split on value {arr[mid]} key value  is {key}");
}





