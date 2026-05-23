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

        List<Color> colors = new List<Color>();
        for (int i = 0; i < CubeEdgesData.edgeDirections.Count; i++) {

            List<int> vector_cd = new List<int>() {
                colorPoints[0].color.ToIntList()[0] - CubeEdgesData.edgeStartingPoints[i][0],
                colorPoints[0].color.ToIntList()[1] - CubeEdgesData.edgeStartingPoints[i][1],
                colorPoints[0].color.ToIntList()[2] - CubeEdgesData.edgeStartingPoints[i][2]
            };

            Matrix matrix = new Matrix(
                new List<List<int>>() {
                    vector_u,
                    vector_v,
                    CubeEdgesData.edgeDirections[i]
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

                int R = (int)(CubeEdgesData.edgeDirections[i][0] * n) + CubeEdgesData.edgeStartingPoints[i][0];
                int G = (int)(CubeEdgesData.edgeDirections[i][1] * n) + CubeEdgesData.edgeStartingPoints[i][1];
                int B = (int)(CubeEdgesData.edgeDirections[i][2] * n) + CubeEdgesData.edgeStartingPoints[i][2];

                if (
                    R >= 0 && R <= byte.MaxValue &&
                    G >= 0 && G <= byte.MaxValue &&
                    B >= 0 && B <= byte.MaxValue
                ) {
                    // Color color = new Color(R, G, B);
                    //
                    // Raylib.DrawSphere(
                    //     color.ToCubePosition(cube), 
                    //     0.05f,
                    //     Color.RayWhite
                    // );
                    
                    colors.Add(new Color(R, G, B));
                }
            }
            
        }
        Raylib.BeginMode3D(camera.camera);
        foreach (Color col in colors) {
            Raylib.DrawSphere(
                col.ToCubePosition(cube), 
                0.05f,
                Color.RayWhite
            );
        }
        Rlgl.Begin(DrawMode.Triangles);
        foreach (Color col in colors) {
            Vector3 worldspacePosition = col.ToCubePosition(cube);
            Rlgl.Color4ub(
                col.R,
                col.G,
                col.B,
                byte.MaxValue
            );
            Rlgl.Vertex3f(
                worldspacePosition.X,
                worldspacePosition.Y,
                worldspacePosition.Z
            );
        }
        Rlgl.End();
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
        // foreach (Triangle3D triangle3D in triangles) {
            // triangle3D.Draw();
        // }
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
        
        ColorComunication.Instance.colorList[2] = new Color(
            20,
            (100 + (int)(60 * Math.Sin(Raylib.GetTime()*0.5f))),
            240
        );
        EdgesComunication.Instance.colorList[2] = new Color(
            20,
            (100 + (int)(60 * Math.Sin(Raylib.GetTime()*0.5f))),
            240
        );
        
        foreach (ColorPoint3D colorPoints in colorPoints) {
            colorPoints.Draw();
        }
    }
}