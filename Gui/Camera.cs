using System.Numerics;
using Raylib_cs;

namespace Gui;

public class Camera {

    private Camera3D _camera;
    public Camera3D camera {
        get {
            return _camera;
        }
    }

    public float fov {
        get { return this._camera.FovY; }
        set { this._camera.FovY = value; }
    }

    public Vector3 position {
        get { return this._camera.Position; }
        set { this._camera.Position = value; }
    }

    public Vector3 target {
        get { return this._camera.Target; }
        set { this._camera.Target = value; }
    }

    public Camera(
        Vector3 position,
        Vector3 target,
        float fov = 45.0f
    ) {
        this.target = target;
        this.position = position;
        this.fov = fov;
        this._camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
        this._camera.Projection = CameraProjection.Perspective;
    }
    public Camera(
    ) : this (
        new Vector3(2.0f, 1.0f, 2.0f),
        new Vector3(0.0f, 0.0f, 0.0f)
    ) { }
}