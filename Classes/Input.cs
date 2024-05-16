using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public static class Input 
{
    private static MouseState _lastmousestate;
    private static Vector2 _direction;
    public static Vector2 Direction => _direction;
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static bool MouseClicked {get; private set;}
    
    public static void Update() {
        var keyboardState = Keyboard.GetState();

        _direction = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
        if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;
    }
}