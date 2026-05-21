using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;

namespace Gui;

public class PlaneScene : Scene3D {
    private Cube3D cube;
    private List<ColorPoint3D> colorsPoints;
    private List<Triangle3D> triangles;

    private bool pointsCreated = false;
    private bool edgesCreated = false;

    public PlaneScene() {
        ColorComunication.Instance.colorList = new List<Color>();
        for (int i = 0; i < 3; i++) {
            ColorComunication.Instance.colorList.Add(new Color());
        }
        
        EdgesComunication.Instance.colorList = new List<Color>();
        for (int i = 0; i < 4; i++) {
            EdgesComunication.Instance.colorList.Add(new Color());
        }
        
        base.camera = camera;
        cube = new Cube3D();
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

        if (!this.edgesCreated) {
            triangles = new List<Triangle3D>();
            triangles.Add(new Triangle3D(
                cube,
                camera,
                renderTexture,
                0,
                1, 
                2
            ));
            triangles.Add(new Triangle3D(
                cube,
                camera,
                renderTexture,
                1, 
                2,
                3
            ));

            edgesCreated = true;
        }
        
        cube.Update();
        foreach (ColorPoint3D colorPoints in colorsPoints) {
            colorPoints.Update();
        }
        foreach (Triangle3D trianlge in triangles) {
            trianlge.Update();
        }
        
    }
    public override void Draw() {
        if (base.camera == null) {
            throw new Exception("No camera attached! to scene");
        }
        Raylib.BeginMode3D(camera.camera);
        cube.Draw();
        Raylib.EndMode3D();

        foreach (Triangle3D triangle in triangles) {
            triangle.Draw();
        }
        
        foreach (ColorPoint3D colorPoints in colorsPoints) {
            colorPoints.Draw();
        }
    }
}