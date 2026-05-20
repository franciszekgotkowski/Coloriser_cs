using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;

namespace Gui;

public class PlaneScene : Scene3D {
    private CubeObject3D cube;
    private List<ColorPoint3D> colorsPoints;

    private bool pointsCreated = false;

    public PlaneScene(
    ) {
        ColorComunication.Instance.colorList = new List<Color>(3);
        for (int i = 0; i < 3; i++) {
            ColorComunication.Instance.colorList.Add(new Color());
        }
        
        base.camera = camera;
        cube = new CubeObject3D();
    }
    
    public override void Update() {
        if (!this.pointsCreated) {
            
            colorsPoints = new List<ColorPoint3D>() {
                new ColorPoint3D(
                    base.camera,
                    base.renderTexture,
                    this.cube,
                    0
                ),
                new ColorPoint3D(
                    base.camera,
                    base.renderTexture,
                    this.cube,
                    1
                ),
                new ColorPoint3D(
                    base.camera,
                    base.renderTexture,
                    this.cube,
                    2
                )
            };
            
            this.pointsCreated = true;
        }
        
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
        Raylib.EndMode3D();
        foreach (ColorPoint3D colorPoints in colorsPoints) {
            colorPoints.Draw();
        }
    }
}