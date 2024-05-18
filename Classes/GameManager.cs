using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DantesPlayground;

public class GameManager {

    public readonly Player player;

    public GameManager(Player plr) {
        player = plr;
        //player = new(General.Content.Load<Texture2D>("DanteIdle-Frame1"), new(200, 200));
    }
    public void Update() {
        InputManager.Update(player);
        player.Update();
    }

    public void Draw() {
        player.Draw();
    }
}