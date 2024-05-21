using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace DantesPlayground;

public class Player : Sprite 
{
    private Vector2 minPos, maxPos;

    public int HP;

    int countercounter = 6;
    int AttackCooldown = 0;
    int AnimationFrame = 0;

    bool IsAttacking;
    public enum Direction {
        Left, Right
    }

    Texture2D[] DanteLeft, DanteRight, DanteUp, DanteDown, DanteAttack;

    private Direction lastDirection;

    private int counter;
    private Song ThunderSound;

    public Player(Texture2D _Texture, Vector2 Position) : base(_Texture, Position) {}

    public void Initialize() {
        lastDirection = Direction.Right;
        IsAttacking = false;
        counter = 0;

        DanteLeft = new Texture2D[10];
        DanteRight = new Texture2D[10];
        DanteUp = new Texture2D[10];
        DanteDown = new Texture2D[10];
        DanteAttack = new Texture2D[5];

        ThunderSound = General.Content.Load<Song>("Thunder");

        for (int i = 0; i < 10; i++) {
            DanteLeft[i] = General.Content.Load<Texture2D>("DanteLeft" + (i + 1));
            DanteRight[i] = General.Content.Load<Texture2D>("DanteRight" + (i + 1));
            DanteUp[i] = General.Content.Load<Texture2D>("DanteUp" + (i + 1));
            DanteDown[i] = General.Content.Load<Texture2D>("DanteDown" + (i + 1));
        }
        for (int i = 0; i < 5; i++) {
            DanteAttack[i] = General.Content.Load<Texture2D>("DanteAttack" + (i + 1));
        }
    }

    public void Update()
    {
        if (AttackCooldown > 0) AttackCooldown--;
        if (!IsAttacking) { 
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
        } else {
            PlayAttackAnim(DanteAttack);
            IsAttacking = false;
        }
        if (InputManager.MouseClicked && InputManager.Direction == Vector2.Zero && AttackCooldown <= 0) IsAttacking = true;
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
        int frameAmount = Animation.Length -1;
        if (counter > countercounter) {
            ChangeSprite(Animation[AnimationFrame]);
            countercounter += 5;
            if (AnimationFrame < frameAmount) {
                AnimationFrame++;
            } else {
                counter = 0; 
                countercounter = 6; 
                AnimationFrame = 0;
            }
        }
    }

    private void PlayAttackAnim(Texture2D[] Animation) {
        counter++;
        int frameAmount = Animation.Length -1;
        if (counter > countercounter) {
            ChangeSprite(Animation[AnimationFrame]);
            countercounter += 5;
            if (AnimationFrame < frameAmount) {
                AnimationFrame++;
            } else {
                counter = 0; 
                countercounter = 6; 
                AnimationFrame = 0;
                AttackCooldown = 120;
                MediaPlayer.Play(ThunderSound);
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
        maxPos = new(mapSize.X - (tileSize.X / 2) - spawn.X, (mapSize.Y - (tileSize.X / 2) - spawn.Y) - tileSize.Y * 2);
    }
}