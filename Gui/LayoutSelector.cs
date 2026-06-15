using raygui_cs;
using Raylib_cs;

namespace Gui;

public class LayoutSelector {
    private Window window;
    private string options;

    private int activeMode = 0;
    private int lastMode = -1;

    private const int bufsize = 100; 
    private bool editMode;

    public LayoutSelector(
        Window window,
        string options
    ) {
        this.window = window;
        this.options = options;
    }

    public void Draw(
        Rectangle rect
    ) {

        if (
            Raygui.GuiDropdownBox(
                rect,
                options,
                ref activeMode,
                editMode
            )
        ) {
            editMode = !editMode; // toggle on click

            if (activeMode != lastMode) {
                lastMode = activeMode;
                Console.WriteLine(activeMode);
                switch (activeMode){
                    case 0:
                        Console.WriteLine("plane layout");
                        window.SetLayout( new PlaneLayout(
                            window
                        ) );
                        break;
                    case 1:
                        Console.WriteLine("null layout");
                        window.SetLayout( null );
                        break;
                    default:
                        Console.WriteLine("break");
                        break;
                }

            }

        }
    }
}