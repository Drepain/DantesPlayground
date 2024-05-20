using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Security.AccessControl;

namespace DantesPlayground;

public class Player : Sprite 
{
    enum Direction {
        Left, Right
    }

    Texture2D[] DanteLeftSprites;

    private Direction lastDirection;

    public Player(Texture2D _Texture, Vector2 Position) : base(_Texture, Position) {}

    public void Initialize() {
        DanteLeftSprites = new Texture2D[11];
        for (int i = 0; i > 10; i++) {
            DanteLeftSprites[i+1] = General.Content.Load<Texture2D>("DanteLeft" + (i + 1));
        }
    }

    public void Update()
    {
        if (InputManager.Direction != Vector2.Zero) {
            var dir = Vector2.Normalize(InputManager.Direction);

            position += dir * speed * General.TotalSeconds;

            //Debug.Print("X:" + dir.X.ToString() + " Y:" + dir.Y.ToString());

            lastDirection = Direction.Right;

            if (dir.X < 0) {
                ChangeSprite(General.Content.Load<Texture2D>("DanteLeft1"));
                Debug.Print("Dante" + (1+1));
                lastDirection = Direction.Left;
            } else if (dir.X > 0) {
                ChangeSprite(General.Content.Load<Texture2D>("DanteRight1"));
                lastDirection = Direction.Right;
            } else if (dir.Y < 0) {
                ChangeSprite(General.Content.Load<Texture2D>("DanteUp1"));
            } else if (dir.Y > 0) {
                ChangeSprite(General.Content.Load<Texture2D>("DanteDown1"));
            } 
        } else {
            if (lastDirection == Direction.Right) {
                ChangeSprite(General.Content.Load<Texture2D>("DanteIdle1"));
            } else {
                ChangeSprite(General.Content.Load<Texture2D>("DanteIdle1"));
            }
        }
    }
}