using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DantesPlayground;

public class Map {
    private readonly Point mapTileSize = new(20, 20);
    private readonly Sprite[,] tiles;
    public Point TileSize {get; private set;}
    public Point MapSize { get; private set;}

    public Map() {
        tiles = new Sprite[mapTileSize.X, mapTileSize.Y];

        List<Texture2D> textures = new(5);
        for (int i = 0; i <= 1; i++) textures.Add(General.Content.Load<Texture2D>($"Floor{i}"));

        TileSize = new(textures[0].Width, textures[0].Height);
        MapSize = new(TileSize.X * mapTileSize.X, TileSize.Y * mapTileSize.Y);

        Random random = new();

        for (int y = 0; y < mapTileSize.Y; y++) {
            for (int x = 0; x < mapTileSize.X; x++) {
                int r = random.Next(0, textures.Count);
                tiles[x,y] = new(textures[r], new(x * TileSize.X, y * TileSize.Y));
            }
        }

    }

    public void Draw() {
        for (int y = 0; y < mapTileSize.Y; y++) {
            for (int x = 0; x < mapTileSize.X; x++) tiles[x,y].Draw();
        }
    }
}