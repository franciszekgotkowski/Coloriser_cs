using System.Numerics;
using Raylib_cs;

namespace Gui;

public static class ColorExtensions {

    public static Vector3 ToVector3(this Color color) {
		return new Vector3(
			color.R,
			color.G,
			color.B
		);
    }
    
    public static List<int> ToIntList(this Color color) {
	    return new List<int>(){
		    (int)color.R,
		    (int)color.G,
		    (int)color.B
	    };
    }

    public static Vector3 ToCubePosition(this Color color, Cube3D cube) {
	    return new Vector3(
		    (((float)color.R / (float)byte.MaxValue))+(cube.position.X - cube.size/2),
		    (((float)color.G / (float)byte.MaxValue))+(cube.position.Y - cube.size/2),
		    (((float)color.B / (float)byte.MaxValue))+(cube.position.Z - cube.size/2)
	    );
    }
    public static Color Add(Color c1, Color c2) {
	    return new Color(
		    c1.R + c2.R,
		    c1.G + c2.G,
		    c1.B + c2.B,
		    c1.A + c2.A
	    );
    }

	public static Color Subtract(Color c1, Color c2) {
		if (
			c1.R < c2.R ||
			c1.G < c2.G ||
			c1.B < c2.B ||
			c1.A < c2.A
		) {
			throw new ArgumentException();
		}
	    return new Color(
		    c1.R - c2.R,
		    c1.G - c2.G,
		    c1.B - c2.B,
		    c1.A - c2.A
	    );
    }

}