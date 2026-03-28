namespace UltimateSortingAlgorithmsTestWithBenchmark.SortingAlgorithm;

public class SortingAlgorithm
{
    public void Setup()
    {
        var e = Generators.GenerateFewUnique(10);
    }

    public void InsertionSort(int[] arr) 
    {
        int n = arr.Length;
        for (int i = 1; i < n; ++i) 
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key) 
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

    public static void Merge(int[] arr, int l, int m, int r)
    {        
        // Find sizes of two
        // subarrays to be merged
        int n1 = m - l + 1;
        int n2 = r - m;

        // Create temp arrays
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];

        // Merge the temp arrays

        // Initial indexes of first
        // and second subarrays
        i = 0;
        j = 0;

        // Initial index of merged
        // subarray array
        int k = l;
        while (i < n1 && j < n2) 
        {
            if (L[i] <= R[j]) 
            {
                arr[k] = L[i];
                i++;
            }
            else 
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        // Copy remaining elements
        // of L[] if any
        while (i < n1) 
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        // Copy remaining elements
        // of R[] if any
        while (j < n2) 
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    // Main function that sorts arr[l..r] using merge()
    public void MergeSort(int[] arr, int l, int r)
    {        
        if (l < r) 
        {
            // Find the middle point
            int m = l + (r - l) / 2;

            // Sort first and second halves
            MergeSort(arr, l, m);
            MergeSort(arr, m + 1, r);

            // Merge the sorted halves
            Merge(arr, l, m, r);
        }
    }

    static int Partition(int[] arr, int low, int high) 
    {
        
        // choose the pivot
        int pivot = arr[high];
        
        // index of smaller element and indicates 
        // the right position of pivot found so far
        int i = low - 1;

        // traverse arr[low..high] and move all smaller
        // elements to the left side. Elements from low to 
        // i are smaller after every iteration
        for (int j = low; j <= high - 1; j++) 
        {
            if (arr[j] < pivot) 
            {
                i++;
                Swap(arr, i, j);
            }
        }
        
        // move pivot after smaller elements and
        // return its position
        Swap(arr, i + 1, high);  
        return i + 1;
    }

    // swap function
    static void Swap(int[] arr, int i, int j) 
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // The QuickSort function implementation
    public void QuickSort(int[] arr, int low, int high) 
    {
        if (low < high) 
        {            
            // pi is the partition return index of pivot
            int pi = Partition(arr, low, high);

            // recursion calls for smaller elements
            // and greater or equals elements
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    public void CSharpArraySort(int[] arr)
    {
        Array.Sort(arr);
    }
}