using System.Numerics;

namespace Gui;

public abstract class Object3D {
    public Vector3 location;
    public abstract void Update();
    public abstract void Draw();

    protected Object3D(
        Vector3 location = new Vector3()
    ) {
        this.location = location;
    }
}