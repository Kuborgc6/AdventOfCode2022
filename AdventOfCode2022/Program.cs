class Program
{
    // A utility function to find the
    // vertex with minimum distance
    // value, from the set of vertices
    // not yet included in shortest
    // path tree
    static int V = 9;
    int minDistance(int[] dist, bool[] sptSet)
    {
        // Initialize min value
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
            }

        return min_index;
    }
    public int dijsktra(int[,] map, int[] starCoord, int[] endCoord, int[,] graph, int src)
    {
        int result = 0;
        int[] dist = new int[V]; // The output array. dist[i]
                                 // will hold the shortest
                                 // distance from src to i

        // sptSet[i] will true if vertex
        // i is included in shortest path
        // tree or shortest distance from
        // src to i is finalized
        bool[] sptSet = new bool[V];

        // Initialize all distances as
        // INFINITE and stpSet[] as false
        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }

        // Distance of source vertex
        // from itself is always 0
        dist[src] = 0;

        // Find shortest path for all vertices
        for (int count = 0; count < V - 1; count++)
        {
            // Pick the minimum distance vertex
            // from the set of vertices not yet
            // processed. u is always equal to
            // src in first iteration.
            int u = minDistance(dist, sptSet);

            // Mark the picked vertex as processed
            sptSet[u] = true;

            // Update dist value of the adjacent
            // vertices of the picked vertex.
            for (int v = 0; v < V; v++)

                // Update dist[v] only if is not in
                // sptSet, there is an edge from u
                // to v, and total weight of path
                // from src to v through u is smaller
                // than current value of dist[v]
                if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }
        return result;
    }

    public int myDijsktra(int[,] map, int[] starCoord, int[] endCoord)
    {
        int result = 0;

        return result;
    }
    static void Main()
    {
        Console.WriteLine("Hello Advent of Code 2022!");

        string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\inputfile.txt");
        string sFilePath = Path.GetFullPath(sFile);
        string[] textInput = @File.ReadAllLines(sFilePath);

        for (int i = 0; i < textInput.Length; i++)
        {
            textInput[i] = textInput[i].Trim();
        }

        int[,] map = new int[textInput.Length, textInput[0].Length];
        int[] startCoord = {0, 0};
        int[] endCoord = { 0, 0 };

        for (int i = 0; i < textInput.Length; i++)
        {
            for(int j = 0; j < textInput[i].Length; j++)
            {
                if (textInput[i][j] == 'S')
                {
                    map[i, j] = 0;
                    startCoord[0] = i;
                    startCoord[1] = j;
                }
                else if (textInput[i][j] == 'E')
                {
                    map[i, j] = 27;
                    endCoord[0] = i;
                    endCoord[1] = j;
                }
                else
                    map[i, j] = textInput[i][j] - 96;
            }
        }
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]+"\t");
            }
            Console.Write("\n");
        }

        Console.WriteLine(startCoord[0] + " " + startCoord[1]);
        Console.WriteLine(endCoord[0] + " " + endCoord[1]);

    }
}