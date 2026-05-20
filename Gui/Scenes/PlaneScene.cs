using Raylib_cs;

namespace Gui;

public class PlaneScene : Scene3D {

    public PlaneScene() {
        base.camera = camera;
        objects.Add(new CubeObject3D());
    }
    
    public override void Update() {
        foreach (Object3D obj in base.objects) {
            obj.Update();
        }
    }
    public override void Draw() {
        if (base.camera == null) {
            throw new Exception("No camera attached! to scene");
        }
        Raylib.BeginMode3D(camera.camera);
        foreach (Object3D obj in base.objects) {
            obj.Draw();
        }
        Raylib.EndMode3D();
    }
}