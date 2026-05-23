namespace Gui;

public static class CubeEdgesData {
    
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

    public static readonly List<List<int>> distanceBetweenEdges = new List<List<int>>();

    static CubeEdgesData() {
        // tutaj odpali się djikstra i poznaduje wszystkie boku a następnie je wypisze tak żebymmógł zrobic nowy graf
    }
}
