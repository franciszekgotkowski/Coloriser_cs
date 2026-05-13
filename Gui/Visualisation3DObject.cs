using System.Numerics;
using Raylib_cs;

namespace Gui;

public class Visualisation3DObject : UiObject {
    private Vector3 defaultCameraLocation = new Vector3(2.0f, 1.0f, 1.0f);
    private float defaultCameraFov = 45.0f;
    private Camera3D camera;
    
    private RenderTexture2D? renderTexture;
    private float cubeSize = 1.0f;

    public Visualisation3DObject(
    ) : base() {
        this.camera = new Camera3D(
            defaultCameraLocation,
            new Vector3(0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),
            defaultCameraFov,
            CameraProjection.Perspective
        );

        this.renderTexture = Raylib.LoadRenderTexture(
            base.coordinates.width,
            base.coordinates.height
        );
    }

    ~Visualisation3DObject() {
        Raylib.UnloadRenderTexture(
            this.renderTexture.Value
        );
    }

    void UpdateRenderTexture() {
        if (this.renderTexture != null) {
            Raylib.UnloadRenderTexture(
                this.renderTexture.Value
            );
            this.renderTexture = null;
        }

        this.renderTexture = Raylib.LoadRenderTexture(
            base.coordinates.width,
            base.coordinates.height
        );
    }
    
    public override void Draw() {
        throw new NotImplementedException();
    }
}