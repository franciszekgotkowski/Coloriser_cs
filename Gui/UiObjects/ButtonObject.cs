using System.Numerics;
using Raylib_cs;

namespace Gui;

public class ButtonObject : UiObject {
    private string text;
    public bool pressed = false;

    public ButtonObject(
        string text,
        int xPos = 0,
        int yPos = 0,
        int width = 0,
        int height = 0
    ) : base(
        xPos,
        yPos,
        width,
        height
    ) {
        this.text = text;
    }

    (int, int) GetTextStartingPosition() {
        (int x, int y) middle = (
            base.coordinates.x + base.coordinates.width / 2,
            base.coordinates.y + base.coordinates.height / 2
        );

        int textWidth = Raylib.MeasureText(this.text, AppTheme.Instance.FontSize);
        middle.x -= textWidth/2;
        
        return middle;
    }

    private void DrawHovered() {
        Raylib.DrawRectangle(
            base.coordinates.x,
            base.coordinates.y,
            base.coordinates.width,
            base.coordinates.height,
            AppTheme.Instance.Theme.hoverFillInColor
            );
        Raylib.DrawRectangleLines(
            base.coordinates.x,
            base.coordinates.y,
            base.coordinates.width,
            base.coordinates.height,
            AppTheme.Instance.Theme.hoverBorderColor
        );
        (int x, int y) pos = GetTextStartingPosition();
        Raylib.DrawText(
            this.text,
            pos.x,
            pos.y,
            AppTheme.Instance.FontSize,
            AppTheme.Instance.Theme.hoverTextColor
        );
    }
    
    private void DrawNotHovered() {
        Raylib.DrawRectangle(
            base.coordinates.x,
            base.coordinates.y,
            base.coordinates.width,
            base.coordinates.height,
            AppTheme.Instance.Theme.fillInColor
        );
        Raylib.DrawRectangleLines(
            base.coordinates.x,
            base.coordinates.y,
            base.coordinates.width,
            base.coordinates.height,
            AppTheme.Instance.Theme.borderColor
        );
        (int x, int y) pos = GetTextStartingPosition();
        Raylib.DrawText(
            this.text,
            pos.x,
            pos.y,
            AppTheme.Instance.FontSize,
            AppTheme.Instance.Theme.textColor
        );
    }
    
    private void DrawPressed() {
        Raylib.DrawRectangle(
            base.coordinates.x,
            base.coordinates.y,
            base.coordinates.width,
            base.coordinates.height,
            AppTheme.Instance.Theme.clickedFillInColor
        );
        Raylib.DrawRectangleLines(
            base.coordinates.x,
            base.coordinates.y,
            base.coordinates.width,
            base.coordinates.height,
            AppTheme.Instance.Theme.clickedBorderColor
        );
        (int x, int y) pos = GetTextStartingPosition();
        Raylib.DrawText(
            this.text,
            pos.x,
            pos.y,
            AppTheme.Instance.FontSize,
            AppTheme.Instance.Theme.clickedTextColor
        );
    }

    public override void Draw() {
        Vector2 v = MouseState.Instance.Position;
        if (
            this.coordinates.Inside(
                MouseState.Instance.PositionX,
                MouseState.Instance.PositionY
            )
        ) {
            if (MouseState.Instance.ButtonLeftDown) {
                DrawPressed();
                this.pressed = true;
            }
            else {
                DrawHovered();
                this.pressed = false;
            }
        }
        else {
            DrawNotHovered();
            this.pressed = false;
        }
    }
}