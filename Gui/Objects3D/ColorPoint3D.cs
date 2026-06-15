using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

namespace Gui;

public class ColorPoint3D : Object3D {
    private readonly Camera camera;
    private readonly RenderTexture renderTexture;
    private readonly Cube3D cube;
    private readonly int colorID;

    public Color color {
        get {
            return ColorCommunication.Instance.colorList[colorID];
        }
    }


    public ColorPoint3D(
        Camera camera,
        RenderTexture renderTexture,
        Cube3D cube,
        int colorId
    ) {
        if (
            camera == null ||
            renderTexture == null ||
            cube == null
        ) {
            throw new NullReferenceException();
        }
        
        this.camera = camera;
        this.renderTexture = renderTexture;
        this.cube = cube;
        this.colorID = colorId;
    }

    public override void Update() {
        this.position = this.color.ToCubePosition(cube);
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