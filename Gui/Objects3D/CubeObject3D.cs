using System.Numerics;
using Raylib_cs;

namespace Gui;

public class CubeObject3D : Object3D {

    public readonly float size;

    public CubeObject3D(
        Vector3 position = new Vector3(),
        float size = 1.0f
    ) : base(position) {
        this.size = size;
    }
    
    public override void Update() {
    }
    
    public override void Draw() {
        Raylib.DrawCubeWires(
            new Vector3(
                base.position[0],
                base.position[1],
                base.position[2]
            ),
            size,
            size,
            size,
            AppTheme.Instance.Theme.borderColor
            );
    }
}