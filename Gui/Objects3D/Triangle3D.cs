using System.Numerics;
using Raylib_cs;

namespace Gui;

public class Triangle3D : Object3D {
    private Cube3D cube;
    private Camera camera;
    private RenderTexture renderTexture;

    Color edge0 {
        get {
            return EdgesComunication.Instance.colorList[idx0];
        }
    }
    Color edge1 {
        get {
            return EdgesComunication.Instance.colorList[idx1];
        }
    }
    Color edge2 {
        get {
            return EdgesComunication.Instance.colorList[idx2];
        }
    }

    private int idx0;
    private int idx1;
    private int idx2;

    public Triangle3D(
        Cube3D cube,
        Camera camera,
        RenderTexture renderTexture,
        int idx0,
        int idx1,
        int idx2
    ) {
        this.cube = cube;
        this.camera = camera;
        this.renderTexture = renderTexture;
        this.idx0 = idx0;
        this.idx1 = idx1;
        this.idx2 = idx2;
    }

    void EdgeDrawingStep(
        Color color
    ) {
        Vector3 worldspacePosition = ColorExtensions.ToCubePosition(
            color, cube
        );
        Rlgl.Color4ub(
            color.R,
            color.G,
            color.B,
            byte.MaxValue
        );
        Rlgl.Vertex3f(
            worldspacePosition.X,
            worldspacePosition.Y,
            worldspacePosition.Z
        );
        
    }
    
    public override void Update() { }
    public override void Draw() {
        Rlgl.Begin(DrawMode.Triangles);
        EdgeDrawingStep(edge0);
        EdgeDrawingStep(edge1);
        EdgeDrawingStep(edge2);
        Rlgl.End();
    }
}