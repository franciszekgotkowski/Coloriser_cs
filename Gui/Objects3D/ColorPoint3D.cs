using Raylib_cs;

namespace Gui;

public class ColorPoint3D : Object3D {
    public Color color;
    private Camera camera;
    private RenderTexture renderTexture;

    public ColorPoint3D(
        Color color,
        Camera camera,
        RenderTexture renderTexture
    ) {
        this.color = color;
        this.camera = camera;
        this.renderTexture = renderTexture;
    }
    
    public override void Update() {
        throw new NotImplementedException();
    }
    public override void Draw() {
        throw new NotImplementedException();
    }
}