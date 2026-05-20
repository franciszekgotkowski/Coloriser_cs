using Raylib_cs;

namespace Gui;

public class PlaneScene : Scene3D {
    private CubeObject3D cube;
    private List<ColorPoint3D> colorsPoints;

    public PlaneScene(
    ) {
        base.camera = camera;
        cube = new CubeObject3D();
        colorsPoints = new List<ColorPoint3D>(3);
    }
    
    public override void Update() {
        cube.Update();
        foreach (ColorPoint3D colorPoints in colorsPoints) {
            colorPoints.Update();
        }
    }
    public override void Draw() {
        if (base.camera == null) {
            throw new Exception("No camera attached! to scene");
        }
        Raylib.BeginMode3D(camera.camera);
        cube.Draw();
        foreach (ColorPoint3D colorPoints in colorsPoints) {
            colorPoints.Draw();
        }
        Raylib.EndMode3D();
    }
}