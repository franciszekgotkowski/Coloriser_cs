using System.Numerics;
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
    public static List<Color> OrderColorsIntoRing(
        List<Color> list,
        List<int> planeVectorU,
        List<int> planeVectorV
    ) {
        // The plane-cube intersection is a convex polygon whose vertices are
        // `list`. Greedy nearest-neighbour ordering does not trace the
        // perimeter of a convex polygon (the closest vertex is often the one
        // across the polygon, not the adjacent one), which produces a
        // self-crossing ring. Instead we sort the vertices by their angle
        // around the centroid, measured inside the plane.
        if (list.Count < 3) {
            return new List<Color>(list);
        }

        Vector3 normal = Vector3.Cross(
            new Vector3(planeVectorU[0], planeVectorU[1], planeVectorU[2]),
            new Vector3(planeVectorV[0], planeVectorV[1], planeVectorV[2])
        );

        Vector3 centroid = Vector3.Zero;
        foreach (Color c in list) {
            centroid += c.ToVector3();
        }
        centroid /= list.Count;

        // First in-plane axis: direction to the vertex farthest from the
        // centroid (numerically stable, never a near-zero vector).
        Vector3 axisU = Vector3.Zero;
        float bestLengthSqr = -1.0f;
        foreach (Color c in list) {
            Vector3 d = c.ToVector3() - centroid;
            if (d.LengthSquared() > bestLengthSqr) {
                bestLengthSqr = d.LengthSquared();
                axisU = d;
            }
        }
        axisU = Vector3.Normalize(axisU);
        // Second in-plane axis, orthogonal to the first.
        Vector3 axisW = Vector3.Normalize(Vector3.Cross(normal, axisU));

        List<Color> output = new List<Color>(list);
        output.Sort((a, b) => {
            Vector3 da = a.ToVector3() - centroid;
            Vector3 db = b.ToVector3() - centroid;
            double angleA = Math.Atan2(Vector3.Dot(da, axisW), Vector3.Dot(da, axisU));
            double angleB = Math.Atan2(Vector3.Dot(db, axisW), Vector3.Dot(db, axisU));
            return angleA.CompareTo(angleB);
        });

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