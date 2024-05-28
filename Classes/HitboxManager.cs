using System.Collections.Generic;
using System.Diagnostics;

namespace DantesPlayground;

public static class HitboxManager {
    public static List<Hitbox> Hitboxes {get; } = new();

    public static void AddHitbox(HitboxData hitboxData) {
        Hitboxes.Add(new(hitboxData));
    }

    public static void Update(Player plr) {
        foreach (var h in Hitboxes) {
            h.Update();
            plr.TakeDamage(h);
        }
        Hitboxes.RemoveAll((h) => h.lastingTime <= 0);
    }
}