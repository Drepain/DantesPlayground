using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace DantesPlayground;

public class Player : Sprite 
{
    enum Direction {
        Up, Down, Left, Right
    }

    public Player(Texture2D _Texture, Vector2 Position) : base(_Texture, Position) {}

    public void Update()
    {
        if (InputManager.Direction != Vector2.Zero) {
            var dir = Vector2.Normalize(InputManager.Direction);

            position += dir * speed * General.TotalSeconds;

            //Debug.Print("X:" + dir.X.ToString() + " Y:" + dir.Y.ToString());

            if (dir.X < 0) {
                texture = General.Content.Load<Texture2D>("DanteLeft1");
            } else if (dir.X > 0) {
                texture = General.Content.Load<Texture2D>("DanteRight1");
            } else if (dir.Y < 0) {
                texture = General.Content.Load<Texture2D>("DanteUp1");
            } else if (dir.Y > 0) {
                texture = General.Content.Load<Texture2D>("DanteDown1");
            } else {
                texture = General.Content.Load<Texture2D>("DanteIdle1");
            }
        } else {
            texture = General.Content.Load<Texture2D>("DanteIdle1");
        }
    }
}