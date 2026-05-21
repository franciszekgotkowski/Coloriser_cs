using System.Numerics;
using Raylib_cs;

namespace Gui;

public class Triangle3D : Object3D {
    private List<Color> edges;
    private Cube3D cube;
    private Camera camera;
    private RenderTexture renderTexture;

    private List<int> indexes = new List<int>();

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
        indexes[0] = idx0;
        indexes[1] = idx1;
        indexes[2] = idx2;
    }
    
    public override void Update() {
        for (int i = 0; i < 3; i++) {
            edges[i] = EdgesComunication.Instance.colorList[indexes[i]];
        }
    }
    public override void Draw() {
        Rlgl.Begin(DrawMode.Triangles);
        
        foreach (Color color in edges) {
            Vector3 worldspacePosition = ColorExtensions.ToCubePosition(
                color, cube
            );
            Vector2 screenspacePosition = Raylib.GetWorldToScreenEx(
                worldspacePosition,
                camera.camera,
                renderTexture.width,
                renderTexture.height
            );
            Rlgl.Color4ub(
                color.R,
                color.G,
                color.B,
                byte.MaxValue
            );
            Rlgl.Vertex2f(
                screenspacePosition.X,
                screenspacePosition.Y
            );
        }
        
        Rlgl.End();

    }
}