using Raylib_cs;
namespace Gui;

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

    public static List<Color> OrderColorsIntoRing(
        List<Color> list
    ) {
        if (list.Count < 2) {
            throw new ArgumentException();
        }
        List<Color> output = new List<Color>();
        
        List<Color> list_cp = new List<Color>();
        foreach (Color c in list) {
            list_cp.Add(c);
        }

        output.Add(list_cp[0]);
        list_cp.RemoveAt(0);

        while (list_cp.Count > 0) {
            List<double> distances = new List<double>();
            foreach (Color c in list_cp) {
                distances.Add(ColorExtensions.Distance(c, output[output.Count-1]));
            }

            double currentDistance = 10000.0f;
            int colorIdx = 0;
            for (int i = 0; i < distances.Count; i++) {
                if (distances[i] < currentDistance) {
                    colorIdx = i;
                    currentDistance = distances[i];
                }
            }
            output.Add(list_cp[colorIdx]);
            list_cp.RemoveAt(colorIdx);
        }

        return output;
    }

    public static List<List<Color>> CreateTrianglesFromOrderedPoints(
        List<Color> list
    ) {
        List<List<Color>> output = new List<List<Color>>();
        
        for (int i = 0; i < list.Count - 2; i++) {
            List<Color> t = new List<Color>() {
                list[0],
                list[i + 1],
                list[i + 2]
            };
            output.Add(t);
        }

        return output;
    }
    
    // tutaj odpali się djikstra i poznaduje wszystkie boku a następnie je wypisze tak żebymmógł zrobic nowy graf
}