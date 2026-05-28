namespace Gui;

using raygui_cs;

public static class CubeEdgesData
{

    public static readonly List<List<int>> edgeStartingPoints = new List<List<int>>() {
        new List<int>() { 0, 0, 0 },
        new List<int>() { byte.MaxValue, 0, 0 },
        new List<int>() { byte.MaxValue, 0, byte.MaxValue},
        new List<int>() { 0, 0, byte.MaxValue },

        new List<int>() { 0, 0, 0 },
        new List<int>() { byte.MaxValue, 0, 0 },
        new List<int>() { byte.MaxValue, 0, byte.MaxValue},
        new List<int>() { 0, 0, byte.MaxValue },

        new List<int>() { 0, byte.MaxValue, 0 },
        new List<int>() { byte.MaxValue, byte.MaxValue, 0 },
        new List<int>() { byte.MaxValue, byte.MaxValue, byte.MaxValue},
        new List<int>() { 0, byte.MaxValue, byte.MaxValue },
    };

    public static readonly List<List<int>> edgeDirections = new List<List<int>>() {
        new List<int>() { 1, 0, 0 },
        new List<int>() { 0, 0, 1 },
        new List<int>() { -1, 0, 0 },
        new List<int>() { 0, 0, -1 },

        new List<int>() { 0, 1, 0 },
        new List<int>() { 0, 1, 0 },
        new List<int>() { 0, 1, 0 },
        new List<int>() { 0, 1, 0 },

        new List<int>() { 1, 0, 0 },
        new List<int>() { 0, 0, 1 },
        new List<int>() { -1, 0, 0 },
        new List<int>() { 0, 0, -1 },
    };

    public static readonly List<List<int>> neighbouringEdgesGraph = new List<List<int>>() {
        new List<int>() {0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
        new List<int>() {1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
        new List<int>() {0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0 },
        new List<int>() {1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0 },
        new List<int>() {1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1 },
        new List<int>() {1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
        new List<int>() {0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
        new List<int>() {0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
        new List<int>() {0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1 },
        new List<int>() {0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0 },
        new List<int>() {0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
        new List<int>() {0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0 }
    };

    public static List<int> OrderPointsToMakeCircle(
        List<int> list
    ) {
        List<List<int>> edges = new List<List<int>>() {
            new List<int>() {0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            new List<int>() {1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            new List<int>() {0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0 },
            new List<int>() {1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0 },
            new List<int>() {1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1 },
            new List<int>() {1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 },
            new List<int>() {0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
            new List<int>() {0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
            new List<int>() {0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1 },
            new List<int>() {0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0 },
            new List<int>() {0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
            new List<int>() {0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0 }
        };

        List<int> diagonala = new List<int>();
        foreach (int i in list) {
            diagonala.Add(i);
        }
        while (diagonala.Count > 0) {
            int t = diagonala[0];
            diagonala.RemoveAt(0);
            if (diagonala.Contains(t)) {
                edges[t][t] += 1;
            }
        }
        
        for (int y = 0; y < edges.Count; y++) {
            for (int x = 0; x < edges[y].Count; x++) {
                if (edges[y][x] == 1 && !list.Contains(x)) {
                    edges[y][x] = 0;
                }
            }
        }
        
        List<int> list_cp = new List<int>();
        foreach (int i in list) {
            diagonala.Add(i);
        }

        
        //bfs-like algorithm
        List<int> visited = new List<int>();
        Queue<int> visitQueue = new Queue<int>();
        int currentlyIn;
        while (list_cp.Count != 0) {
            currentlyIn = list_cp[0];
            list_cp.RemoveAt(0);

            for (int x = 0; x < edges.Count; x++) {
                if (edges[currentlyIn][x] != 0) {
                    visitQueue.Enqueue(edges[currentlyIn][x]);
                }
            }

            while (visitQueue.Peek() != list_cp[0] || visitQueue.Peek() != currentlyIn) {
                if (currentlyIn)
            }
        }
        
        // foreach (List<int> li in CubeEdgesData.neighbouringEdgesGraph) {
        //     foreach (int i in li) {
        //         Console.Write($"{i} ");
        //     }
        //     Console.WriteLine();
        // }
        // Console.WriteLine();
        // foreach (List<int> li in edges) {
        //     foreach (int i in li) {
        //         Console.Write($"{i} ");
        //     }
        //     Console.WriteLine();
        // }

        return null;
    }
    // tutaj odpali się djikstra i poznaduje wszystkie boku a następnie je wypisze tak żebymmógł zrobic nowy graf
}