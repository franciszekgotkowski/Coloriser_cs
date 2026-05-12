using System.Runtime.InteropServices;
using Colorister;

namespace Gui;

using  Raylib_cs;

public class Window {
    private int width, height;
    private int fps;

    private string title;

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

    public void Loop() {
        while (!Raylib.WindowShouldClose()) {
            MouseState.Instance.UpdateMouseState();
            if (Raylib.IsWindowResized()) {
                this.width = Raylib.GetScreenWidth();
                this.height = Raylib.GetScreenHeight();
                UpdatePanesToNewSizes();
                SetCorrectThemeVariables();
            }
            
            rootPane.UpdatePerctentForChildCanvas(40 + Convert.ToInt32(20 * Math.Sin(Raylib.GetTime())));
            UpdatePanesToNewSizes();
            this.DrawProgram();
        }
    }
}