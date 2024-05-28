using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public class AnimationManager
{
    private readonly Dictionary<object, Animation> anims = new();
    private object lastKey;
    private bool Activated;

    public void AddAnimation(object key, Animation animation)
    {
        anims.Add(key, animation);
        lastKey ??= key;
        Activated = true;
    }

    public void Update(object key)
    {
        if (!Activated) return;
        if (anims.ContainsKey(key))
        {
            anims[key].Start();
            anims[key].Update();
            lastKey = key;
        }
        else
        {
            anims[lastKey].Stop();
            anims[lastKey].Reset();
        }
    }

    public void Draw(Vector2 position, bool Flipped)
    {
        anims[lastKey].Draw(position, Flipped);
    }
    
    public void StopAllAnimations() {
        Activated = false;
    }

    public void ResumeAllAnimations() {
        Activated = true;
    }
}