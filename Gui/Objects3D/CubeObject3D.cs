using System.Numerics;
using Raylib_cs;

namespace Gui;

public class CubeObject3D : Object3D {

    private readonly float size;

    public CubeObject3D(
        Vector3 location = new Vector3(),
        float size = 1.0f
    ) : base(location) {
        this.size = size;
    }
    
    public override void Update() {
    }
    
    public override void Draw() {
        Raylib.DrawCubeWires(
            new Vector3(
                base.location[0],
                base.location[1],
                base.location[2]
            ),
            size,
            size,
            size,
            AppTheme.Instance.Theme.borderColor
            );
    }
}