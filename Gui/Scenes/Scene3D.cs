using System.Numerics;

namespace Gui;

public abstract class Scene3D {

    public readonly Camera camera;
    public readonly RenderTexture renderTexture;

    public Scene3D(
        Camera camera,
        RenderTexture renderTexture
    ) {
        
        if (
            camera == null ||
            renderTexture == null
        ) {
            throw new NullReferenceException();
        }
        
        this.camera = camera;
        this.renderTexture = renderTexture;
    }
    
    public abstract void Update();
    public abstract void Draw();
    
}