using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public static class InputManager 
{
    private static Vector2 _direction;
    public static Vector2 Direction => _direction;

    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static bool MouseClicked {get; private set;}
    
    public static void Update() {
        PlayerIndex player = PlayerIndex.One;
        var keyboardState = Keyboard.GetState();
        var GamePadState = GamePad.GetState(player);

        _direction = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.W) || GamePadState.ThumbSticks.Left.Y > 0) {
            _direction.Y--;
        }
        if (keyboardState.IsKeyDown(Keys.S) || GamePadState.ThumbSticks.Left.Y < 0) {
            _direction.Y++;
        }
        if (keyboardState.IsKeyDown(Keys.A) || GamePadState.ThumbSticks.Left.X < 0) {
            _direction.X--;
        }
        if (keyboardState.IsKeyDown(Keys.D) || GamePadState.ThumbSticks.Left.X > 0) {
            _direction.X++;
        }
    }
}