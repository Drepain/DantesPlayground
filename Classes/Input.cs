using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace DantesPlayground;

public static class InputManager 
{
    private static Vector2 _direction, _direction2;
    public static Vector2 Direction => _direction;
    public static Vector2 Direction2 => _direction2;

    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();

    private static ButtonState lastPressed, lastAPressed; 
    public static bool MouseClicked {get; private set;}

    public static bool ButtonClicked {get; private set;}
    
    public static void Update() {
        PlayerIndex player1 = PlayerIndex.One;
        PlayerIndex player2 = PlayerIndex.Two;
        var keyboardState = Keyboard.GetState();
        var GamePadState = GamePad.GetState(player1);
        var GamePadState2 = GamePad.GetState(player2);
        var mouseState = Mouse.GetState();

        _direction = Vector2.Zero;
        _direction2 = Vector2.Zero;

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

        if (mouseState.LeftButton == ButtonState.Pressed && lastPressed == ButtonState.Released) {lastPressed = ButtonState.Pressed; MouseClicked = true;}
        if (mouseState.LeftButton == ButtonState.Released) {lastPressed = ButtonState.Released; MouseClicked = false;}

        if (GamePadState.Buttons.A == ButtonState.Pressed && lastAPressed == ButtonState.Released) {lastAPressed = ButtonState.Pressed; ButtonClicked = true;}
        if (GamePadState.Buttons.A == ButtonState.Released) {lastAPressed = ButtonState.Released; ButtonClicked = false;}
        
        if (GamePadState.ThumbSticks.Left.Y > 0) {
            _direction2.Y--;
        }
        if (GamePadState.ThumbSticks.Left.Y < 0) {
            _direction2.Y++;
        }
        if (GamePadState.ThumbSticks.Left.X < 0) {
            _direction2.X--;
        }
        if (GamePadState.ThumbSticks.Left.X > 0) {
            _direction2.X++;
        }
        
    }
}