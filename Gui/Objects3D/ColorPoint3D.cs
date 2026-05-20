using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

namespace Gui;

public class ColorPoint3D : Object3D {
    private Color color;
    private readonly Camera camera;
    private readonly RenderTexture renderTexture;
    private readonly CubeObject3D cube;
    private readonly int colorID;

    public ColorPoint3D(
        Camera camera,
        RenderTexture renderTexture,
        CubeObject3D cube,
        int colorId
    ) {
        Debug.Assert(camera != null);
        this.camera = camera;
        Debug.Assert(renderTexture != null);
        this.renderTexture = renderTexture;
        Debug.Assert(cube != null);
        this.cube = cube;
        this.colorID = colorId;
    }
    
    public override void Update() {
        this.color = ColorComunication.Instance.colorList[colorID];
        this.position = new Vector3(
            (((float)this.color.R / (float)byte.MaxValue))+(this.cube.position.X - cube.size/2),
            (((float)this.color.G / (float)byte.MaxValue))+(this.cube.position.Y - cube.size/2),
            (((float)this.color.B / (float)byte.MaxValue))+(this.cube.position.Z - cube.size/2)
        );
    }
    public override void Draw() {
        Vector2 screenspacePosition = Raylib.GetWorldToScreenEx(
            this.position,
            this.camera.camera,
            this.renderTexture.width,
            this.renderTexture.height
            );
        Raylib.DrawCircleV(
            screenspacePosition,
            (float)AppTheme.Instance.BorderSize * 1.2f, 
            AppTheme.Instance.Theme.borderColor
            );
        Raylib.DrawCircleV(
            screenspacePosition,
            (float)AppTheme.Instance.BorderSize,
            this.color
        );
    }
}