using raygui_cs;

namespace Gui;

using  Raylib_cs;

public class Window {
    public int width, height;
    public int fps;

    public string title;

    private Pane rootPane;

    public Window (
        int width,
        int height,
        int fps,
        string title,
        Pane rootPane
    ) {

        if (rootPane == null) {
            throw new Exception();
        }

        this.rootPane = rootPane;

        this.width = width;
        this.height = height;
        this.fps = fps;
        this.title = title;

        SetCorrectRootCoordinateVariables();
        SetCorrectThemeVariables();

        this.OpenGuiWindow();

    }

    void SetCorrectThemeVariables() {
        AppTheme.Instance.SetBorderSize((width + height) / 200);
        AppTheme.Instance.SetFontSize(CalculateRightFontSize());
    }

    void SetCorrectRootCoordinateVariables() {
        this.rootPane.SetNewCoordinateVariables(
            AppTheme.Instance.BorderSize,
            AppTheme.Instance.BorderSize,
            this.width - 2 * AppTheme.Instance.BorderSize,
            this.height - 2 * AppTheme.Instance.BorderSize
        );
    }

    int CalculateRightFontSize() {
        int startSize = ((width + height) / 100);

        int i = 20;
        while (i < startSize) {
            i *= 2;
        }

        return i;
    }

    ~Window() {
        Raylib.CloseWindow();
        AppTheme.Instance.WindowCreated = false;
    }

    void OpenGuiWindow() {
        Raylib.SetConfigFlags(
            ConfigFlags.HighDpiWindow |
            ConfigFlags.ResizableWindow
        );
        Raylib.InitWindow(
            this.width,
            this.height,
            this.title
        );
        AppTheme.Instance.WindowCreated = true;
        Rlgl.DisableBackfaceCulling();
        Raylib.SetTargetFPS(fps);
    }

    public void DrawProgram() {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(AppTheme.Instance.Theme.backgroundColor);
        this.rootPane.Draw();

        Raylib.EndDrawing();
    }

    public void UpdatePanesToNewSizes() {
        this.SetCorrectRootCoordinateVariables();
        this.rootPane.ResetCoordinateVariables();
    }

    void HandleWindowResizing() {
        if (Raylib.IsWindowResized()) {
            this.width = Raylib.GetScreenWidth();
            this.height = Raylib.GetScreenHeight();
            UpdatePanesToNewSizes();
            SetCorrectThemeVariables();
        }
    }

    public void Loop() {
        while (!Raylib.WindowShouldClose()) {
            HandleWindowResizing();
            MouseState.Instance.UpdateMouseState();

            if (Raylib.IsKeyPressed(KeyboardKey.K)) {
                if (AppTheme.Instance.Theme == ColorTheme.Kanagawa) {
                    AppTheme.Instance.SetTheme(ColorTheme.LightBlue);
                } else {
                    AppTheme.Instance.SetTheme(ColorTheme.Kanagawa);
                }
            }
            if (Raylib.IsKeyPressed(KeyboardKey.N)) {
                ImageCommunication.Instance.FilePath = "/home/fg/v9.png";
            }
            if (Raylib.IsKeyPressed(KeyboardKey.M)) {
                ImageCommunication.Instance.FilePath = "/home/fg/images.jpeg";
            }
            if (Raylib.IsKeyPressed(KeyboardKey.X)) {
                ImageCommunication.Instance.FilePath = "";
            }

            UpdatePanesToNewSizes();
			DrawProgram();


        }
    }
}
