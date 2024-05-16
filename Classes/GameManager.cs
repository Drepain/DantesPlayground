using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace DantesPlayground;

public class GameManager {

    private readonly Player player;

    public GameManager() {
        player = new(General.Content.Load<Texture2D>("DanteIdle-Sheet"), new(200, 200));
    }
    public void Update() {
        InputManager.Update();
        player.Update();
    }

    public void Draw() {
        player.Draw();
    }
}