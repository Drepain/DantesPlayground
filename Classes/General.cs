using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DantesPlayground;

public static class General {
    
    public static float TotalSeconds;
    public static ContentManager Content{get; set;}
    public static SpriteBatch SpriteBatch {get; set;}

    public static void Update(GameTime gt) {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}