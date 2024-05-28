using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Security;
using System.Collections.Generic;

namespace DantesPlayground;

public class GameManager {

    public readonly Player player1;
    public readonly Player player2;

    public List<Player> Players = new();

    private readonly Map map;
    private Matrix translation;

    public GameManager(Player plr1, Player plr2) {
        player1 = plr1;
        player2 = plr2;

        Players.Add(player1);
        Players.Add(player2);
        //player = new(General.Content.Load<Texture2D>("DanteIdle-Frame1"), new(200, 200));
        map = new();
        player1.SetLimit(map.MapSize, map.TileSize);
        player2.SetLimit(map.MapSize, map.TileSize);
    }

    private void CalculateMatrix() {
        var dx = (1024/2) - (player1.position.X + player2.position.X)/2;
        dx = MathHelper.Clamp(dx, -map.MapSize.X + 1024 + (map.TileSize.X / 2), map.TileSize.X / 2);
        var dy = (768/2) - (player1.position.Y + player2.position.Y)/2;
        dy = MathHelper.Clamp(dy, -map.MapSize.Y + 768 + (map.TileSize.Y / 2), map.TileSize.Y / 2);
        translation = Matrix.CreateTranslation(dx, dy, 0f);
    }

    public void Update() {
        InputManager.Update();
        player1.Update();
        player2.Update();
        HitboxManager.Update(Players);
        CalculateMatrix();
    }

    public void Draw() {
        General.SpriteBatch.Begin(transformMatrix: translation);
        //General.SpriteBatch.DrawString(font, "BALLS", new Vector2(0,0), Color.Red);
        map.Draw();
        player1.Draw();
        player2.Draw();
        General.SpriteBatch.End();
    }
}