using Gui;

namespace Colorister;

public static class App {
    public static void Main(string[] args) {
        
//         // A₁ 3×3 — wymaga eliminacji
//         Matrix mA1 = new Matrix(new List<List<int>> {
//             new List<int>{  2,  1, -1 },
//             new List<int>{ -3, -1,  2 },
//             new List<int>{ -2,  1,  2 },
//         });
//         List<int> lA1 = new List<int>{ 8, -11, -3 };
//         mA1.Print(lA1);
//         mA1.GaussLow(lA1);
//         mA1.Print(lA1);
//
// // A₂ 3×3 — już dolnotrójkątna
//         Matrix mA2 = new Matrix(new List<List<int>> {
//             new List<int>{ 3, 0, 0 },
//             new List<int>{ 6, 2, 0 },
//             new List<int>{ 3, 4, 5 },
//         });
//         List<int> lA2 = new List<int>{ 9, 16, 26 };
//         mA2.Print(lA2);
//         mA2.GaussLow(lA2);
//         mA2.Print(lA2);
//
// // B₁ 4×4 — wymaga eliminacji
//         Matrix mB1 = new Matrix(new List<List<int>> {
//             new List<int>{ 2, 1, 1, 0 },
//             new List<int>{ 4, 3, 3, 1 },
//             new List<int>{ 8, 7, 9, 5 },
//             new List<int>{ 6, 7, 9, 8 },
//         });
//         List<int> lB1 = new List<int>{ 5, 13, 31, 32 };
//         mB1.Print(lB1);
//         mB1.GaussLow(lB1);
//         mB1.Print(lB1);
//
// // B₂ 4×4 — już dolnotrójkątna
//         Matrix mB2 = new Matrix(new List<List<int>> {
//             new List<int>{ 2, 0, 0, 0 },
//             new List<int>{ 1, 3, 0, 0 },
//             new List<int>{ 2, 1, 4, 0 },
//             new List<int>{ 1, 2, 3, 5 },
//         });
//         List<int> lB2 = new List<int>{ 4, 11, 16, 27 };
//         mB2.Print(lB2);
//         mB2.GaussLow(lB2);
//         mB2.Print(lB2);
//         
//         Console.WriteLine("");
//         Console.WriteLine("--------------------------");
//         Console.WriteLine("");
//         
//         Matrix m1 = new Matrix(new List<List<int>> {
//             new List<int>{ 1, 1, 1},
//             new List<int>{ 1, 2, 2},
//             new List<int>{ 2, 3, 4}
//         });
//         List<int> l1 = new List<int>{6, 11, 20};
//         m1.Print(l1);
//         m1.Solve(l1);
//         m1.Print(l1);
//         
//         Matrix m2 = new Matrix(new List<List<int>> {
//             new List<int>{ 2, 1, -1},
//             new List<int>{ 1, 1, 2},
//             new List<int>{ 1, 2, 3}
//         });
//         List<int> l2 = new List<int>{-3, 4, 7};
//         m2.Print(l2);
//         m2.Solve(l2);
//         m2.Print(l2);
//
//         Matrix m3 = new Matrix(new List<List<int>> {
//             new List<int>{1, 0, 1},
//             new List<int>{-2, 1, -1},
//             new List<int>{-3, 2, -1}
//         });
//         List<int> l3 = new List<int>{3, -4, -5};
//         m3.Print(l3);
//         m3.Solve(l3);
//         m3.Print(l3);
//         
//         Matrix m4 = new Matrix(new List<List<int>> {
//             new List<int>{1, 0, 1},
//             new List<int>{-2, 1, -1},
//             new List<int>{1, 0, 1},
//         });
//         List<int> l4 = new List<int>{3, -4, 3};
//         m4.Print(l4);
//         m4.Solve(l4);
//         m4.Print(l4);
//

        
        Pane rootPane = new Pane(
            new NamedBoxObject("siema")
        );
        
        NamedBoxObject tenZTextura = new NamedBoxObject("mam render texture w sobie");
		
        rootPane.AssignChildPane(
            new Pane(tenZTextura),
            30,
            Direction.RIGHT
        );
		
        rootPane.childPane.AssignChildPane(
            new Pane(
                new ButtonObject(
                    "Jestem trzeci!"
                )
            ),
            50,
            Direction.DOWN
        );


        Window window = new Window(
            800,
            600,
            60,
            "Ciszarp",
            rootPane
        );

        tenZTextura.AddGuiObject(
            new Visualisation3DObject(
                new PlaneScene()
            )
        );
        AppTheme.Instance.SetTheme(ColorTheme.Kanagawa);

        window.Loop();
    }
}