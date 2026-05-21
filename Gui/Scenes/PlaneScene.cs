using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;

namespace Gui;

public class PlaneScene : Scene3D {
    readonly private Cube3D cube;
    
    private readonly ColorPoint3D[] colorPoints = new ColorPoint3D[3];
    private readonly Triangle3D[] triangles = new Triangle3D[2];

    public PlaneScene(
        Camera camera,
        RenderTexture renderTexture
    ) : base(
        camera, 
        renderTexture
    ) {
        cube = new Cube3D();

        ColorComunication.Instance.colorList = new Color[3];
        EdgesComunication.Instance.colorList = new Color[4];

        colorPoints[0] = new ColorPoint3D(
            base.camera,
            base.renderTexture,
            this.cube,
            0
        );
        colorPoints[1] = new ColorPoint3D(
            base.camera,
            base.renderTexture,
            this.cube,
            1
        );
        colorPoints[2] = new ColorPoint3D(
            base.camera,
            base.renderTexture,
            this.cube,
            2
        );

        triangles[0] = new Triangle3D(
            this.cube,
            this.camera,
            this.renderTexture,
            0, 1, 2
        );
        triangles[1] = new Triangle3D(
            this.cube,
            this.camera,
            this.renderTexture,
            1, 2, 3
        );

    }

    class CubeEdge {
        private List<int> direction = new List<int>();
        private List<int> startingPoint = new List<int>();

        public CubeEdge(
            List<int> direction,
            List<int> startingPoint
        ) {
            if (
                direction.Count != 3 ||
                startingPoint.Count != 3 
            ) {
                throw new ArgumentException();
            }
        }
    }

    void UpdatePlaneData() {
        
        List<List<int>> edgeStartingPoints = new List<List<int>>() {
            new List<int>() { 0, 0, 0 },
            new List<int>() { byte.MaxValue, 0, 0 },
            new List<int>() { byte.MaxValue, 0, byte.MaxValue},
            new List<int>() { 0, 0, byte.MaxValue },
            
            new List<int>() { 0, 0, 0 },
            new List<int>() { byte.MaxValue, 0, 0 },
            new List<int>() { byte.MaxValue, 0, byte.MaxValue},
            new List<int>() { 0, 0, byte.MaxValue },
            
            new List<int>() { 0, byte.MaxValue, 0 },
            new List<int>() { byte.MaxValue, byte.MaxValue, 0 },
            new List<int>() { byte.MaxValue, byte.MaxValue, byte.MaxValue},
            new List<int>() { 0, byte.MaxValue, byte.MaxValue },
        };

        List<List<int>> edgeDirections = new List<List<int>>() {
            new List<int>() { 1, 0, 0 },
            new List<int>() { 0, 0, 1 },
            new List<int>() { -1, 0, 0 },
            new List<int>() { 0, 0, -1 },
            
            new List<int>() { 0, 1, 0 },
            new List<int>() { 0, 1, 0 },
            new List<int>() { 0, 1, 0 },
            new List<int>() { 0, 1, 0 },
            
            new List<int>() { 1, 0, 0 },
            new List<int>() { 0, 0, 1 },
            new List<int>() { -1, 0, 0 },
            new List<int>() { 0, 0, -1 },
        };

    }
    
    public override void Update() {
        
        cube.Update();
        foreach (ColorPoint3D colorPoints in this.colorPoints) {
            colorPoints.Update();
        }
        
    }
    public override void Draw() {
        if (base.camera == null) {
            throw new Exception("No camera attached! to scene");
        }
        Raylib.BeginMode3D(camera.camera);
        cube.Draw();
        foreach (Triangle3D triangle3D in triangles) {
            triangle3D.Draw();
        }
        Raylib.EndMode3D();

        
        foreach (ColorPoint3D colorPoints in colorPoints) {
            colorPoints.Draw();
        }
    }
}