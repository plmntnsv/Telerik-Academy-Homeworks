using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        // Assert for empty and null array
        Debug.Assert(arr.Length > 0, "Empty array provided.");
        Debug.Assert(arr != null, "Invalid array provided.");
        for (int index = 0; index < arr.Length-1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        // Assert for empty and null array
        Debug.Assert(arr != null, "Invalid array provided.");
        Debug.Assert(arr.Length > 0, "Empty array provided.");

        // Assert that the start and end indices are within the length of the array
        Debug.Assert(0 <= startIndex && startIndex < arr.Length, "Start index is outside the boundaries of the array.");
        Debug.Assert(0 < endIndex && endIndex <= arr.Length, "End index is outside the boundaries of the array.");

        // Assert that the start index is smaller than the end index
        Debug.Assert(startIndex < endIndex, "Start index cannot be bigger than the end index.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        // Assert that the found index of the minimal element is within the length of the array
        Debug.Assert(0 <= minElementIndex && minElementIndex <= arr.Length, "The index of the minimal element is outside the boundaries of the array.");
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        // Assert that x and/or y are of reference type (correct me if this assert is irrelevant)
        Debug.Assert(default(T) != null, "Not a reference/nullable type parameter/s provided.");

        T oldX = x;
        x = y;
        y = oldX;

        // Assert that x and y are not null
        Debug.Assert(x != null, "X parameter is null.");
        Debug.Assert(y != null, "Y parameter is null.");
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        // Assert against empty array and null value
        Debug.Assert(arr.Length > 0, "Empty array provided.");
        Debug.Assert(value != null, "Value cannot be null.");

        int indexOfValue = BinarySearch(arr, value, 0, arr.Length - 1);

        // Assert that the middle index in within the length of the array
        Debug.Assert(0 <= indexOfValue && indexOfValue < arr.Length, "The index of the middle element is outside the boundaries of the array.");
        return indexOfValue;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        // Assert that the array is not null or empty
        Debug.Assert(arr != null, "Invalid array provided.");
        Debug.Assert(arr.Length > 0, "Empty array provided.");

        // Assert that value is not null
        Debug.Assert(value != null, "Value cannot be null.");

        // Assert that the start and end indices are within the lenght of the array
        Debug.Assert(0 < startIndex || startIndex < arr.Length, "Start index is outside the boundaries of the array.");
        Debug.Assert(0 < endIndex || endIndex < arr.Length, "End index is outside the boundaries of the array.");
        
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        // Test sorting array
        // int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        // Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        // SelectionSort(arr);
        // Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        // Test sorting empty array
        // int[] arr = new int[0];
        // Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        // SelectionSort(arr);
        // Console.WriteLine("sorted = [{0}]", string.Join(", ", arr)); 

        // Test sorting array with 1 element
        // SelectionSort(new int[1]); // Test sorting single element array
        // int[] arr = new int[1] { 1000 };
        // Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        // SelectionSort(arr);
        // Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        //Should Fail
        // Console.WriteLine(BinarySearch(arr, -1000));
        // Console.WriteLine(BinarySearch(arr, 10));

        //Should be correct
        // Console.WriteLine(BinarySearch(arr, 0));
        // Console.WriteLine(BinarySearch(arr, 17));

        // Should be correct with array with one element
        // Console.WriteLine(BinarySearch(arr, 1000));
    }
}
