using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public class GameManager {

    public readonly Player player;
    private Matrix translation;

    public GameManager(Player plr) {
        player = plr;
        //player = new(General.Content.Load<Texture2D>("DanteIdle-Frame1"), new(200, 200));
    }

    private void CalculateMatrix() {
        var dx = (1024/2) - player.position.X;
        var dy = (768/2) - player.position.Y;
        translation = Matrix.CreateTranslation(dx, dy, 0f);
    }

    public void Update() {
        InputManager.Update();
        player.Update();
        CalculateMatrix();
    }

    public void Draw() {
        General.SpriteBatch.Begin(transformMatrix: translation);
        //General.SpriteBatch.DrawString(font, "BALLS", new Vector2(0,0), Color.Red);
        player.Draw();
        
        General.SpriteBatch.End();
    }
}