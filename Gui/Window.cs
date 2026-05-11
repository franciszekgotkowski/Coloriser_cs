using Colorister;

namespace Gui;

using  Raylib_cs;

public class Window {
    private int width, height;
    private int fps;
    private int borderWidth;
    private Color clearColor;

    private string title;

    private Pane rootPane;
    
    public Window (
        int width,
        int height,
        int fps,
        string title,
        Color? clearColor = null
    ) {
        Color realClearColor = Color.White;
        if (clearColor != null) {
            realClearColor = this.clearColor;
        }
        
        this.borderWidth = (width + height) / 200;

        this.width = width;
        this.height = height;
        this.fps = fps;
        this.clearColor = realClearColor;
        this.title = title;

        this.rootPane.SetNewCoordinateVariables(
            this.borderWidth,
            this.borderWidth,
            this.width - 2 * borderWidth,
            this.height - 2 * borderWidth,
            this.borderWidth
        );
    }

    
    void OpenGuiWindow() {
        Raylib.SetConfigFlags(ConfigFlags.HighDpiWindow);
        Raylib.InitWindow(
            this.width,
            this.height,
            this.title
        );
        // Raylib.DisableBackfaceCulling();

        Raylib.SetTargetFPS((int)fps);
    }
    
    public void DrawProgram() {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(this.clearColor);
        this.rootPane.Draw();
        Raylib.EndDrawing();
    }

    public void UpdatePanesToNewSizes() {
        this.rootPane.ResetCoordinateVariables();
    }

    public Window(
        int i
    ) {
        Raylib.InitWindow(800, 480, "Hello World");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Rectangle rect = new Rectangle(10.0f, 10.0f, 50.0f, 50.0f);
            Rectangle rect2 = new Rectangle(70.0f, 70.0f, (float)(200.0f+Math.Sin(Raylib.GetTime())*150.0f), 100.0f);
            GuiFunctions.DrawBox(rect);
                
            GuiFunctions.DrawNamedBox(
                rect2,
                "uszanowanko z podełeczka"
            );

            Raylib.DrawText("Hello, wo!", 12, 12, 20, Color.Black);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}