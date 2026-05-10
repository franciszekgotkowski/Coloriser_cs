using Colorister;

namespace Gui;

using  Raylib_cs;

public class Window {
    private uint width, height, fps;
    private Color color;

    public Window() {
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