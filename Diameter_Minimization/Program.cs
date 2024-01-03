class Solution
{
    static Queue<int> q = new Queue<int>();
    static int[] dis = new int[1001];

    static int BFS(int n, int m, int x)
    {
        Array.Fill(dis, 1_000_000_000);
        dis[x] = 0;
        q.Enqueue(x);
        int mmh = 0;

        while (q.Count > 0)
        {
            int k = q.Dequeue();
            mmh = dis[k];

            for (int i = 0; i < m; i++)
            {
                int j = (k * m + i) % n;

                if (dis[j] > mmh + 1)
                {
                    dis[j] = mmh + 1;
                    q.Enqueue(j);
                }
            }
        }
        return mmh;
    }
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        Array.Resize(ref dis, n);

        int mmh = 0;
        for (int i = 0; i < n; i++)
        {
            mmh = Math.Max(mmh, BFS(n, m, i));
        }

        Console.WriteLine(mmh);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write((i * m + j) % n + " ");
            }
            Console.WriteLine();
        }
    }
}
