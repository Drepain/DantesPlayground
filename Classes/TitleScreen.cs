using System.Net.Mime;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public class TitleScreen {

    private SpriteFont font;
    public TitleScreen() {}

    public void Initialize() {
        font = General.Content.Load<SpriteFont>("ComicSans");
    }

    public void Draw() {
        General.SpriteBatch.DrawString(font, "MonoGame Font Test", new Vector2(0,0), Color.White, 0, new Vector2(0,0), 1.0f, SpriteEffects.None, 0.5f);
    }
}