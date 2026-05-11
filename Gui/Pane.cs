namespace Gui;

using Raylib_cs;

public class Pane {
    IntRect paneCoordinates;
    IntRect canvasCoordinates;
    int borderWidth;
    private Direction whereIsChild = Direction.UNKNOWN;
    
    private string name;


    // this function runs SetNewCoordinateVariables with the its data so it can correct its dividing after adding new element

    public Pane childPane;
    public UiObject uiObject;
    public int percentOfCanvasForChild = 50;

    public Pane(
        int xPos = 0,
        int yPos = 0,
        int width = 0,
        int heigth = 0,
        int borderWidth = 0,
        string name = "ERROR: NO NAME",
        UiObject uiObject = null
    ) {
        
    }

    public Pane(
        string name,
        UiObject uiObject
    ) {
        
    }

    public Pane GetChildPane() {
        return new Pane();
    }

    // If there is some window resize or function initialization this function will be called
    // It (based on the data it recieved) sets new coordinates for position and child width and height. This function will be used recursively for updating UI
    public void SetNewCoordinateVariables(
        int xPos,
        int yPos,
        int width,
        int heigth,
        int borderSize
    ) {
        
    }

    public void ResetCoordinateVariables() {
        this.SetNewCoordinateVariables(
            this.paneCoordinates.X,
            this.paneCoordinates.Y,
            this.paneCoordinates.Width,
            this.paneCoordinates.Height,
            this.borderWidth
        );
    }

    public void AssignUiObject (
        UiObject newUiObject
    ) {
        
    }

    public void AssignChildPane(
        Pane childPanePtr,
        int canvasPercentForCHild,
        Direction childLocation
    ) {
        
    }

    // you need to be in raylibs drawing mode to start
    public void Draw() {
        
    }
};