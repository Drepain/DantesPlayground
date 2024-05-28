using System.Buffers;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DantesPlayground;

public class Animation {
    private readonly Texture2D[] textures;
    private readonly int frames;
    private int frame;
    private readonly float frameTime;
    private float frameTimeLeft;
    private bool active = true;
    private readonly Vector2 origin;

    private bool loop;

    public Animation(Texture2D[] Textures, float FrameTime, Vector2 Origin, bool Loop = false) {
        textures = Textures;
        frameTime = FrameTime;
        frameTimeLeft = frameTime;
        frames = Textures.Length;
        origin = Origin;
        loop = Loop;
    }

    public void Stop()
    {
        active = false;
    }

    public void Start() {
        active = true;
    }

    public void Reset() {
        frame = 0;
        frameTimeLeft = frameTime;
    }

    public void Update() {
        if (!active) return;
        frameTimeLeft -= General.TotalSeconds;
        
        if(frameTimeLeft <= 0) {
            
            frameTimeLeft += frameTime;
            frame = (frame + 1) % frames;
            if (frame == frames - 1 && !loop) { Stop();}
        }

        
    }
    public void Draw(Vector2 pos, bool Flipped = false) {
        if (!Flipped) General.SpriteBatch.Draw(textures[frame], pos, null, Color.White, 0, origin, 1, SpriteEffects.None, 1); 
        else General.SpriteBatch.Draw(textures[frame], pos, null, Color.White, 0, origin, 1, SpriteEffects.FlipHorizontally, 1); 
    }
}