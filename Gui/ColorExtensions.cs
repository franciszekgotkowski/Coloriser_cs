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

    public static Vector3 ToCubePosition(this Color color, Cube3D cube) {
	    return new Vector3(
		    (((float)color.R / (float)byte.MaxValue))+(cube.position.X - cube.size/2),
		    (((float)color.G / (float)byte.MaxValue))+(cube.position.Y - cube.size/2),
		    (((float)color.B / (float)byte.MaxValue))+(cube.position.Z - cube.size/2)
	    );
    }

}