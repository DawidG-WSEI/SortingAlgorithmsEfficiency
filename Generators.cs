public static class Generators
{
    public static int[] GenerateRandom(int size, int minVal = 1, int maxVal = 100)
    {
        int[] a = new int[size];
        for(int i = 0; i < size; i++)
        {
            a[i] = Random.Shared.Next(minVal, maxVal + 1);
        }
        return a;
    }

    public static int[] GenerateSorted(int size, int minVal = 1, int maxVal = 100)
    {
        int[] a = GenerateRandom(size, minVal, maxVal);
        Array.Sort(a);
        return a;
    }

    public static int[] GenerateReversed(int size, int minVal = 1, int maxVal = 100)
    {
        int[] a = GenerateSorted(size, minVal, maxVal);
        Array.Reverse(a);
        return a;
    }

    public static int[] GenerateAlmostSorted(int size, int minVal = 1, int maxVal = 100)
    {
        int[] a = GenerateSorted(size, minVal, maxVal);
        for(int i = 0; i <= size / 10; i++)
        {
            int idx1 = Random.Shared.Next(0, size);
            int idx2 = Random.Shared.Next(0, size);
            (a[idx1], a[idx2]) = (a[idx2], a[idx1]);
        }
        return a;
    }
    
    public static int[] GenerateFewUnique(int size)
    {
        int[] a = new int[size];
        for(int i = 0; i < size; i++)
        {
            a[i] = Random.Shared.Next(1, 11);
        }
        return a;
    }
}