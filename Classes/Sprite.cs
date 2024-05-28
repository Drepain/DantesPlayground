using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public class Sprite
{
    public Texture2D texture;
    public bool Flipped;
    public Vector2 position;
    public readonly Vector2 spawn;
    public float speed;
    public Rectangle Hitbox;

    public Sprite(Texture2D _Texture, Vector2 Position) 
    {
        texture = _Texture;
        position = Position;
        speed = 300;
        spawn = new(_Texture.Width / 2, _Texture.Height / 2);
        Flipped = false;
        Hitbox = new Rectangle((int)position.X, (int)position.Y, 160, 160);
    }

    public virtual void Draw()
    {
        if (!Flipped) General.SpriteBatch.Draw(texture, position, null, Color.White, 0, spawn, 1, SpriteEffects.None, 1);
        else General.SpriteBatch.Draw(texture, position, null, Color.White, 0, spawn, 1, SpriteEffects.FlipHorizontally, 1);
    }

    public void ChangeSprite(Texture2D newTexture) {
        texture = newTexture;
    }

}