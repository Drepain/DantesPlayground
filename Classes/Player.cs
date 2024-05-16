using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO.Pipes;

namespace DantesPlayground;

public class Player : Sprite 
{
    public Player(Texture2D _Texture, Vector2 Position) : base(_Texture, Position) {}

    public void Update()
    {
        if (InputManager.Direction != Vector2.Zero) {
            var dir = Vector2.Normalize(InputManager.Direction);

            position += dir * speed * General.TotalSeconds;
        }
    }
}