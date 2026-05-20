using System.Runtime.CompilerServices;
using Raylib_cs;

namespace Gui;

public static class VectorMath {
    
    public static IntVector3[] Make2Vectors(
        Color c1,
        Color c2,
        Color c3
    ) {

        return new IntVector3[] {
            new IntVector3(c1, c3),
            new IntVector3(c2, c3)
        };
        
    }

    // returns index of line with contradiction
    public static int IsThereContradiction(
        Matrix m,
        List<int> l
    ) {
        if (m.data.Count != l.Count) {
            throw new Exception("Incorrect input data!");
        }

        for (int i = 0; i < l.Count; i++) {
            if (
                m.data[i][0] == 0 &&
                m.data[i][1] == 0 &&
                m.data[i][2] == 0 &&
                l[i] != 0
            ) {
                return i;
            }
        }

        return -1;
    }
    
    // returns index of null row
    public static int IsThereNullRow(
        Matrix m,
        List<int> l
    ) {
        if (m.data.Count != l.Count) {
            throw new Exception("Incorrect input data!");
        }

        for (int i = 0; i < l.Count; i++) {
            if (
                m.data[i][0] == 0 &&
                m.data[i][1] == 0 &&
                m.data[i][2] == 0 &&
                l[i] == 0
            ) {
                return i;
            }
        }

        return -1;
    }
    
    
    
    // vec_u*a + vec_v*b + vec_c = vec_z*n + vec_d
    // =>
    // -vec_u*a - vec_v*b + vec_z*n = vec_c - vec_d
    public static ColorInt FindIntersectionPoint(
        IntVector3 v,
        IntVector3 u,
        IntVector3 c,
        IntVector3 d,
        IntVector3 z
    ) {
        Matrix m = new Matrix(
            new List<List<int>> {
                new List<int> { -u[0], -v[0], z[0] },
                new List<int> { -u[1], -v[1], z[1] },
                new List<int> { -u[2], -v[2], z[2] }
            }
        );

        IntVector3 iv = new IntVector3(
            c[0] - d[0],
            c[1] - d[1],
            c[2] - d[2]
        );

        List<int> l = (List<int>)iv;

        m.Solve(l);
        int contradiction = IsThereContradiction(m, l);
        int nullRow = IsThereNullRow(m, l);

        if (contradiction != -1) {
            return null;
        }

        if (nullRow != -1) {
            return (ColorInt)(z + d);
        }

        return new ColorInt(
            (uint)l[0],
            (uint)l[1],
            (uint)l[2]
        );
    }
    
}