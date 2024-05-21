using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public class GameManager {

    public readonly Player player;

    private readonly Map map;
    private Matrix translation;

    public GameManager(Player plr) {
        player = plr;
        //player = new(General.Content.Load<Texture2D>("DanteIdle-Frame1"), new(200, 200));
        map = new();
        player.SetLimit(map.MapSize, map.TileSize);
    }

    private void CalculateMatrix() {
        var dx = (1024/2) - player.position.X;
        dx = MathHelper.Clamp(dx, -map.MapSize.X + 1024 + (map.TileSize.X / 2), map.TileSize.X / 2);
        var dy = (768/2) - player.position.Y;
        dy = MathHelper.Clamp(dy, -map.MapSize.Y + 768 + (map.TileSize.Y / 2), map.TileSize.Y / 2);
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
        map.Draw();
        player.Draw();
        
        General.SpriteBatch.End();
    }
}