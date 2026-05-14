using System.Runtime.CompilerServices;

namespace Gui;

using Raylib_cs;

public class RenderTexture {

    public RenderTexture2D renderTexture {
        get;
        private set;
    }
    private bool active = false;

    public int width {
        get;
        private set;
    }

    public int height {
        get;
        private set;
    }


    public RenderTexture(
        int width,
        int height
    ) {
        this.renderTexture = Raylib.LoadRenderTexture(
            width, 
            height
        );
        this.width = width;
        this.height = height;
    }

    ~RenderTexture() {
        this.Deactivate();
        Raylib.UnloadRenderTexture(
            this.renderTexture
        );
    }

    public void Resize(
        int widht,
        int height
    ) {

        if (
            this.width == widht &&
            this.height == height
        ) {
            return;
        }
        
        this.width = widht;
        this.height = height;
        bool active = false;
        if (this.active) {
            this.Deactivate();
            active = true;
        }
        Raylib.UnloadRenderTexture(
            this.renderTexture
        );
        this.renderTexture = Raylib.LoadRenderTexture(
            widht,
            height
        );
        if (active) {
            this.Activate();
        }
    }

    public void Activate() {
        if (!active) {
            Raylib.BeginTextureMode(
                this.renderTexture
            );
            this.active = true;
        }
    }

    public void Deactivate() {
        if (active) {
            Raylib.EndTextureMode();
            this.active = false;
        }
    }
}