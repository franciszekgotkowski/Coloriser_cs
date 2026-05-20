using System.ComponentModel;
using Raylib_cs;

namespace Gui;

public class IntVector3 {
	private int[] Data { get; set; } = new int[3];

	public int this[int idx] {
		get
		{
			return this.Data[idx];
		}
		set {
			Data[idx] = value;
		}
	}

	public IntVector3(
		Color c1,
		Color c2
	) {
		Data[0] = c2.R - c1.R;
		Data[1] = c2.G - c1.G;
		Data[2] = c2.B - c1.B;
	}

	public IntVector3(
		int i0,
		int i1,
		int i2
	) {
		this.Data[0] = i0;
		this.Data[1] = i1;
		this.Data[2] = i2;
	}

	public static explicit operator List<int>(IntVector3 iv3) {
		return new List<int>{iv3[0], iv3[1], iv3[2]};
	}
	
	public static IntVector3 operator +(IntVector3 v1, IntVector3 v2) {
		IntVector3 iv = new IntVector3(
			v1[0] + v2[0],
			v1[1] + v2[1],
			v1[2] + v2[2]
		);

		return iv;
	}

	public static IntVector3 operator -(IntVector3 v1, IntVector3 v2) {
		IntVector3 iv = new IntVector3(
			v1[0] - v2[0],
			v1[1] - v2[1],
			v1[2] - v2[2]
		);

		return iv;
	}

	public static explicit operator ColorInt(IntVector3 iv3) {
		return new ColorInt(
			(uint)iv3.Data[0],
			(uint)iv3.Data[1],
			(uint)iv3.Data[2]
		);
	}
}