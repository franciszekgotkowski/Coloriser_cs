using System.Numerics;
using Raylib_cs;

namespace Gui;

public class ColorInt {
	public uint R;
	public uint G;
	public uint B;
	public uint A;

	public ColorInt(
		Color color
	) {
		this.R = color.R;
		this.G = color.G;
		this.B = color.B;
		this.A = color.A;
	}

	public ColorInt(
		uint R,
		uint G,
		uint B,
		uint A = byte.MaxValue
	)
	{
		this.R = R;
		this.G = G;
		this.B = B;
		this.A = A;
	}

	public static implicit operator ColorInt(Color c) => new ColorInt(c);

	public Vector3 ToVector3() {
		return new Vector3(
			(float)R,
			(float)G,
			(float)B
		);
	}

}