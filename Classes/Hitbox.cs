using System.Diagnostics;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public class Hitbox {

    public float lastingTime;
    public Player owner;
    Vector2 position, size;
    public Rectangle box;
    public Hitbox(HitboxData info) {
        lastingTime = info.LastingTime;
        position = info.Position;
        size = info.Size;
        owner = info.Owner;
        Initialize();
    }

    public void Initialize() {
        box = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        //Debug.Print("Hitbox:" + box.ToString());
    }

    public void Update() {
        lastingTime -= General.TotalSeconds;
    }
}