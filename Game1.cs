using System.IO;
using System.Net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DantesPlayground;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont font;
    private  GameManager ManageGame;
    public static float TotalSeconds;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.IsBorderless = false;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        _graphics.PreferredBackBufferWidth = 1536;
        _graphics.PreferredBackBufferHeight = 1024;
        _graphics.ApplyChanges();

        General.Content = Content;
        ManageGame = new();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        General.SpriteBatch = _spriteBatch;

        font = Content.Load<SpriteFont>("HackFont");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        General.Update(gameTime);

        ManageGame.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.DrawString(font, "BALLS", new Vector2(0,0), Color.Red);
        ManageGame.Draw();

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
