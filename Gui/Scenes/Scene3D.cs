using System.Numerics;

namespace Gui;

public abstract class Scene3D {

    public Camera? camera;
    
    protected List<Object3D> objects = new List<Object3D>();
    
    public abstract void Update();
    public abstract void Draw();
    
}