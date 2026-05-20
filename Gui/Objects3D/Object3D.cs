using System.Numerics;

namespace Gui;

public abstract class Object3D {
    public Vector3 position;
    public abstract void Update();
    public abstract void Draw();

    protected Object3D(
        Vector3 position = new Vector3()
    ) {
        this.position = position;
    }
}