using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DantesPlayground;

public static class InputManager 
{
    private static Vector2 _direction;
    public static Vector2 Direction => _direction;
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static bool MouseClicked {get; private set;}
    
    public static void Update(Player plr) {
        var keyboardState = Keyboard.GetState();

        _direction = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.W)) {
            _direction.Y--;
        }
        if (keyboardState.IsKeyDown(Keys.S)) {
            _direction.Y++;
        }
        if (keyboardState.IsKeyDown(Keys.A)) {
            _direction.X--;
        }
        if (keyboardState.IsKeyDown(Keys.D)) {
            _direction.X++;
        }
    }
}