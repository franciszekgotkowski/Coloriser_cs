using System.Numerics;
using Raylib_cs;

namespace Gui;

public class MouseState {

    private MouseState() { }

    public static readonly MouseState Instance = new MouseState();

    public Vector2 Position {
        get;
        private set;
    } = new Vector2();
    public Vector2 Delta{
        get;
        private set;
    } = new Vector2();

    public Vector2 WheelMove {
        get;
        private set;
    } = new Vector2();
    
    public int PositionX {
        get => Convert.ToInt32(this.Position.X);
    } 
    public int PositionY {
        get => Convert.ToInt32(this.Position.Y);
    } 
    
    public int WheelMoveX {
        get => Convert.ToInt32(this.WheelMove.X);
    } 
    public int WheelMoveY {
        get => Convert.ToInt32(this.WheelMove.Y);
    }

    public int DeltaX {
        get => Convert.ToInt32(this.Delta.X);
    } 
    public int DeltaY {
        get => Convert.ToInt32(this.Delta.Y);
    }


    public bool ButtonLeftDown {
        get;
        private set;
    } = false;
    public bool ButtonRightDown {
        get;
        private set;
    } = false;
    public bool ButtonMiddleDown {
        get;
        private set;
    } = false;

    public bool ButtonLeftPressed {
        get;
        private set;
    } = false;
    public bool ButtonRightPressed {
        get;
        private set;
    } = false;
    public bool ButtonMiddlePressed {
        get;
        private set;
    } = false;
    
    public bool ButtonLeftReleased {
        get;
        private set;
    } = false;
    public bool ButtonRightReleased {
        get;
        private set;
    } = false;
    public bool ButtonMiddleReleased {
        get;
        private set;
    } = false;


    public bool ButtonLeftUp {
        get;
        private set;
    } = false;
    public bool ButtonRightUp {
        get;
        private set;
    } = false;
    public bool ButtonMiddleUp {
        get;
        private set;
    } = false;


    public void UpdateMouseState() {
        this.Position = Raylib.GetMousePosition();
        this.Delta = Raylib.GetMouseDelta();
        
        this.ButtonLeftDown = Raylib.IsMouseButtonDown(MouseButton.Left);
        this.ButtonRightDown = Raylib.IsMouseButtonDown(MouseButton.Right);
        this.ButtonMiddleDown = Raylib.IsMouseButtonDown(MouseButton.Middle);
        
        this.ButtonLeftPressed = Raylib.IsMouseButtonPressed(MouseButton.Left);
        this.ButtonRightPressed = Raylib.IsMouseButtonPressed(MouseButton.Right);
        this.ButtonMiddlePressed = Raylib.IsMouseButtonPressed(MouseButton.Middle);
        
        this.ButtonLeftReleased = Raylib.IsMouseButtonReleased(MouseButton.Left);
        this.ButtonRightReleased = Raylib.IsMouseButtonReleased(MouseButton.Right);
        this.ButtonMiddleReleased = Raylib.IsMouseButtonReleased(MouseButton.Middle);
        
        this.ButtonLeftUp = Raylib.IsMouseButtonUp(MouseButton.Left);
        this.ButtonRightUp = Raylib.IsMouseButtonUp(MouseButton.Right);
        this.ButtonMiddleUp = Raylib.IsMouseButtonUp(MouseButton.Middle);

        this.WheelMove = Raylib.GetMouseWheelMoveV();
    }
}