using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Security;
using System.Collections.Generic;
using System.Diagnostics;

namespace DantesPlayground;

public class GameManager {

    public readonly Player player1;
    public readonly Player player2;

    private Sprite mainscreen, controls;

    private enum GameState {
        MainMenu, ControlsMenu, InGame
    }

    private GameState currentGameState;
    public List<Player> Players = new();

    private readonly Map map;
    private Matrix translation;

    public GameManager(Player plr1, Player plr2) {
        player1 = plr1;
        player2 = plr2;
        currentGameState = GameState.MainMenu;
        translation = Matrix.CreateTranslation(0,0,0);

        Players.Add(player1);
        Players.Add(player2);
        //player = new(General.Content.Load<Texture2D>("DanteIdle-Frame1"), new(200, 200));

        mainscreen = new(General.Content.Load<Texture2D>("TitleScreen"), new(1024/2,768/2));
        controls = new(General.Content.Load<Texture2D>("ControlScreen"), new(1024/2,768/2));
        
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
        if (currentGameState == GameState.MainMenu && (InputManager.MouseClicked || InputManager.ButtonClicked)) {
            currentGameState = GameState.ControlsMenu;
        }
        if ((currentGameState == GameState.ControlsMenu || currentGameState == GameState.MainMenu) && (InputManager.Direction != Vector2.Zero || InputManager.Direction2 != Vector2.Zero)) {
            currentGameState = GameState.InGame;
        }
        if (currentGameState == GameState.InGame) {
            player1.Update();
            player2.Update();
            HitboxManager.Update(Players);
            CalculateMatrix();
        }
    }

    public void Draw() {
        General.SpriteBatch.Begin(transformMatrix: translation);
        //General.SpriteBatch.DrawString(font, "BALLS", new Vector2(0,0), Color.Red);
        if (currentGameState == GameState.InGame) {
            map.Draw();
            player1.Draw();
            player2.Draw();
        } else if (currentGameState == GameState.MainMenu) {
            mainscreen.Draw();
        } else if (currentGameState == GameState.ControlsMenu) {
            controls.Draw();
        }
        General.SpriteBatch.End();
    }
}