using System.ComponentModel;
using System.Numerics;
using Raylib_cs;

namespace Gui;

public class PlaneScene : Scene3D {
    readonly private Cube3D cube;
    
    private readonly ColorPoint3D[] colorPoints = new ColorPoint3D[3];
    private List<int> vector_v;
    private List<int> vector_u;
    
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


        vector_v = new List<int>(){
            -(colorPoints[1].color.R - colorPoints[0].color.R),
            -(colorPoints[1].color.G - colorPoints[0].color.G),
            -(colorPoints[1].color.B - colorPoints[0].color.B),
        };
        
        vector_u = new List<int>(){
            -(colorPoints[2].color.R - colorPoints[0].color.R),
            -(colorPoints[2].color.G - colorPoints[0].color.G),
            -(colorPoints[2].color.B - colorPoints[0].color.B),
        };

        Raylib.BeginMode3D(camera.camera);
        for (int i = 0; i < edgeDirections.Count; i++) {

            List<int> vector_cd = new List<int>() {
                colorPoints[0].color.ToIntList()[0] - edgeStartingPoints[i][0],
                colorPoints[0].color.ToIntList()[1] - edgeStartingPoints[i][1],
                colorPoints[0].color.ToIntList()[2] - edgeStartingPoints[i][2]
            };

            Matrix matrix = new Matrix(
                new List<List<int>>() {
                    vector_u,
                    vector_v,
                    edgeDirections[i]
                }
            );
            matrix.Transpose();
            matrix.Solve(vector_cd);

            if (
                !matrix.IsDiagonalInconsistent(vector_cd)
            ) {
                float a, b, n;
                a = (float)vector_cd[0] / matrix.data[0][0];
                b = (float)vector_cd[1] / matrix.data[1][1];
                n = (float)vector_cd[2] / matrix.data[2][2];
                Console.WriteLine(n);

                int R = (int)(edgeDirections[i][0] * n) + edgeStartingPoints[i][0];
                int G = (int)(edgeDirections[i][1] * n) + edgeStartingPoints[i][1];
                int B = (int)(edgeDirections[i][2] * n) + edgeStartingPoints[i][2];

                if (
                    R >= 0 && R <= byte.MaxValue &&
                    G >= 0 && G <= byte.MaxValue &&
                    B >= 0 && B <= byte.MaxValue
                ) {
                    Color color = new Color(R, G, B);
                
                    Raylib.DrawSphere(
                        color.ToCubePosition(cube), 
                        0.05f,
                        Color.RayWhite
                    );
                }
            }
            
        }
        Raylib.EndMode3D();
    }
    
    public override void Update() {
        
        cube.Update();
        foreach (ColorPoint3D colorPoints in this.colorPoints) {
            colorPoints.Update();
        }
        UpdatePlaneData();
        
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

        ColorComunication.Instance.colorList[1] = new Color(
            170,
            (130 + (int)(100 * Math.Sin(Raylib.GetTime()))),
            130
        );
        EdgesComunication.Instance.colorList[1] = new Color(
            170,
            (130 + (int)(100 * Math.Sin(Raylib.GetTime()))),
            130
        );
        
        foreach (ColorPoint3D colorPoints in colorPoints) {
            colorPoints.Draw();
        }
    }
}