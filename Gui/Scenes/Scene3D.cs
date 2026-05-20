using System.Numerics;

namespace Gui;

public abstract class Scene3D {

    public Camera? camera;
    public RenderTexture? renderTexture;
    
    public abstract void Update();
    public abstract void Draw();
    
}