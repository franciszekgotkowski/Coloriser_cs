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

}