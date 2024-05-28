using System.Collections.Generic;
using System.Diagnostics;

namespace DantesPlayground;

public static class HitboxManager {
    public static List<Hitbox> Hitboxes {get; } = new();

    public static void AddHitbox(HitboxData hitboxData) {
        Hitboxes.Add(new(hitboxData));
    }

    public static void Update(List<Player> players) {
        foreach (var h in Hitboxes) {
            h.Update();
            foreach (var p in players) {
                p.TakeDamage(h);
            }
        }
        Hitboxes.RemoveAll((h) => h.lastingTime <= 0);
    }
}