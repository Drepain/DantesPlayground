using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public class Sprite
{
    protected Texture2D texture;
    public Vector2 position;
    private Vector2 spawn;
    public int speed;

    public Sprite(Texture2D _Texture, Vector2 Position) 
    {
        texture = _Texture;
        position = Position;
        speed = 300;
        spawn = new(_Texture.Width / 2, _Texture.Height / 2);
    }

    public virtual void Draw()
    {
        General.SpriteBatch.Draw(texture, position, null, Color.White, 0, spawn, 1, SpriteEffects.None, 1);
    }

    public void ChangeSprite(Texture2D newTexture) {
        texture = newTexture;
    }
}