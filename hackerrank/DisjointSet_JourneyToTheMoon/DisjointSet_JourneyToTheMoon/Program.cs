using System;

class Solution
{
    static ulong journeyToMoon(int n, int[][] astronaut)
    {

        // Initialize disjoint set
        var ds = new int[n];
        for (var i = 0; i < n; i++)
        {
            ds[i] = i;
        }

        var count = new int[n];
        for (var i = 0; i < n; i++)
        {
            count[i] = 0;
        }

        var rank = new int[n];
        for (var i = 0; i < n; i++)
        {
            rank[i] = 0;
        }

        for (var i = 0; i < astronaut.Length; i++)
        {
            Union(ds, rank, astronaut[i][0], astronaut[i][1]);
        }

        FillCount(ds, count);

        int sum = 0;
        ulong result = 0;
        for (var i = 0; i < n; i++)
        {
            if (count[i] == 0) { continue; }
            result += (ulong) sum*(ulong) count[i];
            sum += count[i];
        }

        return result;
    }

    static void FillCount(int[] ds, int[] count)
    {
        for (var i = 0; i < ds.Length; i++)
        {
            var parent = Find(ds, i);
            count[parent]++;
        }
    }

    static void Union(int[] ds, int[] rank, int a1, int a2)
    {
        var a1Parent = Find(ds, a1);
        var a2Parent = Find(ds, a2);

        if (rank[a1Parent] < rank[a2Parent])
        {
            ds[a1Parent] = a2Parent;
        }
        else
        {
            ds[a2Parent] = a1Parent;
            rank[a1Parent]++;
        }
    }

    static int Find(int[] ds, int index)
    {
        var parent = index;
        while (parent != ds[parent])
        {
            parent = ds[parent];
        }
        ds[index] = parent;
        return parent;
    }
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int p = Convert.ToInt32(tokens_n[1]);
        int[][] astronaut = new int[p][];
        for (int astronaut_i = 0; astronaut_i < p; astronaut_i++)
        {
            string[] astronaut_temp = Console.ReadLine().Split(' ');
            astronaut[astronaut_i] = Array.ConvertAll(astronaut_temp, Int32.Parse);
        }
        ulong result = journeyToMoon(n, astronaut);
        Console.WriteLine(result);
    }
}
