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
	public Color Project(
		Color c1,
		Color c2,
		Color c3
	) {

		this.R -= c1.R;
		this.G -= c1.G;
		this.B -= c1.B;

		List<int> v1 = new List<int>() {
			(int)c2.R - c1.R,
			(int)c2.G - c1.G,
			(int)c2.B - c1.B
		};
		List<int> v2 = new List<int>() {
			(int)c3.R - c1.R,
			(int)c3.G - c1.G,
			(int)c3.B - c1.B
		};

		List<int> n = new List<int>() {
			v1[1]*v2[2] - v2[1]*v1[2],
			v1[2]*v2[0] - v2[2]*v1[0],
			v1[0]*v2[1] - v2[0]*v1[1]
		};

		double n_abs_sqr = n[0]*n[0] + n[1]*n[1] + n[2]*n[2];
		double mul = (int)(R * n[0] + G * n[1] + B * n[2]);

		List<int> n1 = new List<int>() {
			(int)((double)(n[0] * mul) / n_abs_sqr),
			(int)((double)(n[1] * mul) / n_abs_sqr),
			(int)((double)(n[2] * mul) / n_abs_sqr)
		};

		List<int> ret = new List<int>() {
			(int)(R - n1[0] + c1.R),
			(int)(G - n1[1] + c1.G),
			(int)(B - n1[2] + c1.B)
		};

		for (int i = 0; i < 3; i++) {
			if (ret[i] < 0) ret[i] = 0;
			if (ret[i] > byte.MaxValue) ret[i] = byte.MaxValue;
		}

		return new Color(
			ret[0],
			ret[1],
			ret[2],
			byte.MaxValue
		);
	}

}


