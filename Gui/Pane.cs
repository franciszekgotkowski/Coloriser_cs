using System.Diagnostics;

namespace Gui;

public class Pane {
    IntRect paneCoordinates;
    IntRect canvasCoordinates;
    private Direction whereIsChild = Direction.UNKNOWN;

    // this is a way to store child pane
    public Pane? childPane;
    // this is a way to store object that will draw this pane's content
    public UiObject? uiObject;
    public int percentOfCanvasForUiObject = 50;

    public Pane(
        UiObject? uiObject = null,
        int xPos = 0,
        int yPos = 0,
        int width = 0,
        int heigth = 0
    ) {
        this.uiObject = uiObject;
        this.SetNewCoordinateVariables(
            xPos,
            yPos,
            width,
            heigth
        ); 
    }

    // If there is some window resize or function initialization this function will be called
    // It (based on the data it recieved) sets new coordinates for position and child width and height. This function will be used recursively for updating UI
    public void SetNewCoordinateVariables(
        int x,
        int y,
        int width,
        int heigth
    ) {
        this.paneCoordinates = new IntRect(
            x,
            y,
            width,
            heigth
        );

        this.canvasCoordinates = new IntRect(
            x,
            y,
            width,
            heigth
        );

        IntRect childCoordinates;
        IntRect uiObjectCoordinates;

        if (this.childPane == null) {
            this.percentOfCanvasForUiObject = 0;
            if (this.uiObject == null) {
                return;
            }
        }
        if (this.childPane != null) {
            switch (this.whereIsChild) {
                case Direction.LEFT:
                    childCoordinates = new IntRect(
                        this.canvasCoordinates.x,
                        this.canvasCoordinates.y,
                        (this.canvasCoordinates.width - AppTheme.Instance.BorderSize) * this.percentOfCanvasForUiObject / 100,
                        this.canvasCoordinates.height
                    );
                    uiObjectCoordinates = new IntRect(
                        this.canvasCoordinates.x + childCoordinates.width + AppTheme.Instance.BorderSize,
                        this.canvasCoordinates.y,
                        this.canvasCoordinates.width - (childCoordinates.width + AppTheme.Instance.BorderSize),
                        this.canvasCoordinates.height
                    );
                    break;
                case Direction.RIGHT:
                    uiObjectCoordinates = new IntRect(
                        this.canvasCoordinates.x,
                        this.canvasCoordinates.y,
                        (this.canvasCoordinates.width - AppTheme.Instance.BorderSize) * this.percentOfCanvasForUiObject / 100,
                        this.canvasCoordinates.height
                    );
                    childCoordinates = new IntRect(
                        this.canvasCoordinates.x + uiObjectCoordinates.width + AppTheme.Instance.BorderSize,
                        this.canvasCoordinates.y,
                        this.canvasCoordinates.width - (uiObjectCoordinates.width + AppTheme.Instance.BorderSize),
                        this.canvasCoordinates.height
                    );
                    break;
                case Direction.UP:
                    childCoordinates = new IntRect(
                        this.canvasCoordinates.x,
                        this.canvasCoordinates.y,
                        this.canvasCoordinates.width,
                        (this.canvasCoordinates.height - AppTheme.Instance.BorderSize) * this.percentOfCanvasForUiObject / 100
                    );
                    uiObjectCoordinates = new IntRect(
                        this.canvasCoordinates.x,
                        this.canvasCoordinates.y + AppTheme.Instance.BorderSize + childCoordinates.height,
                        this.canvasCoordinates.width,
                        this.canvasCoordinates.height - (childCoordinates.height + AppTheme.Instance.BorderSize)
                    );
                    break;
                case Direction.DOWN:
                    uiObjectCoordinates = new IntRect(
                        this.canvasCoordinates.x,
                        this.canvasCoordinates.y,
                        this.canvasCoordinates.width,
                        (this.canvasCoordinates.height - AppTheme.Instance.BorderSize) * this.percentOfCanvasForUiObject / 100
                    );
                    childCoordinates = new IntRect(
                        this.canvasCoordinates.x,
                        this.canvasCoordinates.y + AppTheme.Instance.BorderSize + uiObjectCoordinates.height,
                        this.canvasCoordinates.width,
                        this.canvasCoordinates.height - (uiObjectCoordinates.height + AppTheme.Instance.BorderSize)
                    );
                    break;
                default:
                    childCoordinates = new IntRect();
                    uiObjectCoordinates = new IntRect();
                    Debug.Assert(false);
                    break;
            }
            this.childPane.SetNewCoordinateVariables(
                childCoordinates.x,
                childCoordinates.y,
                childCoordinates.width,
                childCoordinates.height
            );
        } else {
            uiObjectCoordinates = new IntRect(
                this.canvasCoordinates.x,
                this.canvasCoordinates.y,
                this.canvasCoordinates.width,
                this.canvasCoordinates.height
            );
        }


        if (this.uiObject != null) {
            this.uiObject.Resize(
                uiObjectCoordinates.x,
                uiObjectCoordinates.y,
                uiObjectCoordinates.width,
                uiObjectCoordinates.height
            );
        }  
    }
    
    public void ResetCoordinateVariables() {
        this.SetNewCoordinateVariables(
            this.paneCoordinates.x,
            this.paneCoordinates.y,
            this.paneCoordinates.width,
            this.paneCoordinates.height
        );
    }
 
    public void AssignChildPane(
        Pane childPane,
        int canvasPercentForChild,
        Direction childLocation
    ) {
        if (childPane != null) {
            this.childPane = childPane;
            this.percentOfCanvasForUiObject = canvasPercentForChild;
            this.whereIsChild = childLocation;
        }
        this.ResetCoordinateVariables();
    }

    public void UpdatePerctentForChildCanvas(
        int percent
    ) {
        this.percentOfCanvasForUiObject = percent;
        this.ResetCoordinateVariables();
    }
    
    // you need to be in raylibs drawing mode to start
    public void Draw() {
        if (this.uiObject != null) {
            this.uiObject.Draw();
        }
        
        if (this.childPane != null) {
            this.childPane.Draw();
        }
    }
};
