using System.Numerics;
using Raylib_cs;

namespace Gui;

public class Visualisation3DObject : UiObject {
    public Camera camera;
    public RenderTexture renderTexture;
    public Scene3D? scene;
    
    public Visualisation3DObject(
        int width = 0,
        int height = 0
    ) : base() {
        this.camera = new Camera();
        this.renderTexture = new RenderTexture(
            width,
            height
        );
    }
    
    public override void Resize(
        int xPos, 
        int yPos, 
        int width, 
        int height
    )  {
        base.Resize(xPos, yPos, width, height);
        if (this.renderTexture != null) {
            this.renderTexture.Resize(width, height);
        }
    }

    public void AddScene3D(
        Scene3D scene
    ) {
        if (scene == null) {
            throw new NullReferenceException();
        }

        this.scene = scene;
    }

    public override void Draw() {
        renderTexture.Activate();
        Raylib.ClearBackground(AppTheme.Instance.Theme.backgroundColor);

        this.camera.position = new Vector3(
            2.0f * (float)Math.Sin(Raylib.GetTime()/5.0f),
            this.camera.position.Y,
            2.0f * (float)Math.Cos(Raylib.GetTime()/5.0f)
        );

        if (scene == null) {
            throw new Exception("Scene not initialized");
        }

        this.scene.Update();
        this.scene.Draw();
        
        renderTexture.Deactivate();
        Raylib.DrawTextureRec(
            this.renderTexture.renderTexture.Texture,
            new Rectangle(
                0.0f,
                0.0f,
                this.renderTexture.width,
                -this.renderTexture.height
            ),
            new Vector2(
                base.coordinates.x,
                base.coordinates.y
            ),
            Color.White
        );
    }
}