
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public sealed class HitboxData {
    public Vector2 Position {get; set;}
    public Vector2 Size {get; set;}
    public float LastingTime {get; set;}
    public Player Owner {get; set;}
}