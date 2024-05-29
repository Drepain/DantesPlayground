using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;

namespace DantesPlayground;

public class Player : Sprite 
{
    private Vector2 minPos, maxPos;

    private Rectangle hitbox;
    public int index;
    private bool AttackButtonPressed;
    public int HP;
    int AttackCooldown = 0;
    public int AttackDuration = 30;

    public enum Direction {
        Left, Right
    }

    enum State {
        Normal, Stunned, Invulnerable, Attacking
    }

    private State playerstate;

    Texture2D[] DanteLeft, DanteRight, DanteUp, DanteDown, DanteAttack;

    private Direction lastDirection;

    private SoundEffect ThunderSound;

    private Vector2 DirectionVector;

    private Animation AttackAnim, WalkUp, WalkDown, WalkRight, Still;

    private AnimationManager Animations;

    public Player(Texture2D _Texture, Vector2 Position, int PlayerIndex = 1) : base(_Texture, Position) {
        index = PlayerIndex;
    }
    

    public void Initialize() {
        hitbox.Height = texture.Height;
        hitbox.Width = texture.Width;

        lastDirection = Direction.Right;
        playerstate = State.Normal;

        Animations = new();

        DanteLeft = new Texture2D[10];
        DanteRight = new Texture2D[10];
        DanteUp = new Texture2D[10];
        DanteDown = new Texture2D[10];
        DanteAttack = new Texture2D[5];

        ThunderSound = General.Content.Load<SoundEffect>("Thunder");

        for (int i = 0; i < 10; i++) {
            DanteLeft[i] = General.Content.Load<Texture2D>("DanteLeft" + (i + 1));
            DanteRight[i] = General.Content.Load<Texture2D>("DanteRight" + (i + 1));
            DanteUp[i] = General.Content.Load<Texture2D>("DanteUp" + (i + 1));
            DanteDown[i] = General.Content.Load<Texture2D>("DanteDown" + (i + 1));
        }
        for (int i = 0; i < 5; i++) {
            DanteAttack[i] = General.Content.Load<Texture2D>("DanteAttack" + (i + 1));
        }

        AttackAnim = new(DanteAttack, 0.1f, spawn, false);
        WalkUp = new(DanteUp, 0.1f, spawn, true);
        WalkDown = new(DanteDown, 0.1f, spawn, true);
        WalkRight = new(DanteRight, 0.1f, spawn, true);
        Still = new(new[] {General.Content.Load<Texture2D>("DanteIdle1")}, 1f, spawn, false);

        Animations.AddAnimation(new Vector2(0,1), WalkDown);
        Animations.AddAnimation(new Vector2(0,0), Still);
        Animations.AddAnimation(new Vector2(0,-1), WalkUp);
        Animations.AddAnimation(new Vector2(1,0), WalkRight);
        Animations.AddAnimation(new Vector2(-1,0), WalkRight);
        Animations.AddAnimation(new Vector2(1,1), WalkDown);
        Animations.AddAnimation(new Vector2(-1,-1), WalkUp);
        Animations.AddAnimation(new Vector2(1,-1), WalkUp);
        Animations.AddAnimation(new Vector2(-1,1), WalkDown);

        

        //AttackAnimations.AddAnimation(true, AttackAnim);
    }

    public void Update()
    {
        switch (index)
        {
            case 1:
            DirectionVector = InputManager.Direction;
            AttackButtonPressed = InputManager.MouseClicked;
            break;
            case 2:
            DirectionVector = InputManager.Direction2;
            AttackButtonPressed = InputManager.ButtonClicked;
            break;
        }

        if (playerstate == State.Attacking) {
            if (lastDirection == Direction.Right) {
                DirectionVector = new Vector2(200f, 0);
                
            } else if (lastDirection == Direction.Left) {
                DirectionVector = new Vector2(-200f, 0);
            }
        }

        if (AttackCooldown > 0) {AttackCooldown--;}
        if (AttackDuration > 0) {AttackDuration--;}

        if (AttackDuration <= 0 && playerstate == State.Attacking) {
            Fire();
            //Debug.Print("Player:" + position.ToString());
            playerstate = State.Normal;
            ThunderSound.CreateInstance().Play();
            AttackAnim.Reset();
        }

        if (DirectionVector != Vector2.Zero) {
            var dir = Vector2.Normalize(DirectionVector);

            position += dir * speed * General.TotalSeconds * 1.3f;

            if (DirectionVector.X > 0) lastDirection = Direction.Right;
            if (DirectionVector.X < 0) lastDirection = Direction.Left;

            position = Vector2.Clamp(position, minPos, maxPos);

            //Position can be debugged with:
            //Debug.Print("X:" + position.X.ToString() + " Y:" + position.Y.ToString());
        }
        
        if (AttackButtonPressed && AttackCooldown <= 0) {
            AttackAnim.Start();
            playerstate = State.Attacking;
            AttackCooldown = 120;
            AttackDuration = 30;
        }

        if (lastDirection == Direction.Right) Flipped = false;
        else if (lastDirection == Direction.Left) Flipped = true;
        
        UpdateHitbox();

        Animations.Update(DirectionVector);
        if (playerstate == State.Attacking) {
            AttackAnim.Update();
        }
    }

    public void SetLimit(Point mapSize, Point tileSize) {
        minPos = new((-tileSize.X / 2) + spawn.X, (-tileSize.Y / 2) + spawn.Y);
        maxPos = new(mapSize.X - (tileSize.X / 2) - spawn.X, (mapSize.Y - (tileSize.X / 2) - spawn.Y) - tileSize.Y * 2);
    }

    private void Fire() {
        HitboxData hd = new()
        {
            Position = position,
            Size = new Vector2(this.texture.Width, this.texture.Height),
            LastingTime = General.TotalSeconds,
            Owner = this
        };
        HitboxManager.AddHitbox(hd);
    }

    public void TakeDamage(Hitbox hb) {
        if (playerstate != State.Invulnerable) {
            if (hb.box.Intersects(hitbox) && hb.owner != this) {
                Debug.Print("ouch");
            }
        }
    }

    private void UpdateHitbox() {
        hitbox.X = (int)position.X;
        hitbox.Y = (int)position.Y;
    }

    public override void Draw() {
        if (playerstate == State.Normal) {
            Animations.Draw(position, Flipped);
        } else {
            AttackAnim.Draw(position, Flipped);
        }
    }
}