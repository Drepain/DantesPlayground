using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace DantesPlayground;

public class Player : Sprite 
{
    private Vector2 minPos, maxPos;

    int countercounter = 6;
    int AnimationFrame = 0;
    public enum Direction {
        Left, Right
    }

    Texture2D[] DanteLeft, DanteRight, DanteUp, DanteDown;

    private Direction lastDirection;

    private int counter;

    public Player(Texture2D _Texture, Vector2 Position) : base(_Texture, Position) {}

    public void Initialize() {
        lastDirection = Direction.Right;
        counter = 0;

        DanteLeft = new Texture2D[10];
        DanteRight = new Texture2D[10];
        DanteUp = new Texture2D[10];
        DanteDown = new Texture2D[10];

        for (int i = 0; i < 10; i++) {
            DanteLeft[i] = General.Content.Load<Texture2D>("DanteLeft" + (i + 1));
            DanteRight[i] = General.Content.Load<Texture2D>("DanteRight" + (i + 1));
            DanteUp[i] = General.Content.Load<Texture2D>("DanteUp" + (i + 1));
            DanteDown[i] = General.Content.Load<Texture2D>("DanteDown" + (i + 1));
        }
    }

    public void Update()
    {
        if (InputManager.Direction != Vector2.Zero) {
            var dir = Vector2.Normalize(InputManager.Direction);

            position += dir * speed * General.TotalSeconds * 1.3f;

            position = Vector2.Clamp(position, minPos, maxPos);

            //Position can be debugged with:
            //Debug.Print("X:" + position.X.ToString() + " Y:" + position.Y.ToString());
            
            if (dir.Y < 0) {
                PlayAnimation(DanteUp);
            } else if (dir.Y > 0) {
                PlayAnimation(DanteDown);
            } else if (dir.X < 0) {
                PlayAnimation(DanteLeft);
                lastDirection = Direction.Left;
            } else if (dir.X > 0) {
                PlayAnimation(DanteRight);
                lastDirection = Direction.Right;
            }
        } else 
        {
            ChangeSprite(General.Content.Load<Texture2D>("DanteIdle1"));
            ResetAnimationParams();
        }
    }

    public Direction GetDirection() {
        return lastDirection switch
        {
            Direction.Left => Direction.Left,
            Direction.Right => Direction.Right,
            _ => Direction.Left,
        };
    }

    private void PlayAnimation(Texture2D[] Animation) {
        counter++;
        if (counter > countercounter) {
            ChangeSprite(Animation[AnimationFrame]);
            countercounter += 6;
            if (AnimationFrame < 9) {
                AnimationFrame++;
            } else {
                counter = 0; 
                countercounter = 6; 
                AnimationFrame = 0;
            }
        }
    }

    void ResetAnimationParams() {
        counter = 0;
        countercounter = 0;
        AnimationFrame = 0;
    }

    public void SetLimit(Point mapSize, Point tileSize) {
        minPos = new((-tileSize.X / 2) + spawn.X, (-tileSize.Y / 2) + spawn.Y);
        maxPos = new(mapSize.X - (tileSize.X / 2) - spawn.X, mapSize.Y - (tileSize.X / 2) - spawn.Y);
    }
}