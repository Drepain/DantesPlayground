using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Globalization;

namespace DantesPlayground;

public class Map {
    private readonly Point mapTileSize = new(20, 20);
    private readonly Sprite[,] tiles;
    public Point TileSize {get; private set;}
    public Point MapSize { get; private set;}

    public Map() {
        tiles = new Sprite[mapTileSize.X, mapTileSize.Y];

        List<Texture2D> textures = new(6);
        for (int i = 0; i <= 1; i++) textures.Add(General.Content.Load<Texture2D>($"Floor{i}"));
        textures.Add(General.Content.Load<Texture2D>("Wall1"));
        textures.Add(General.Content.Load<Texture2D>("WallEdge"));
        textures.Add(General.Content.Load<Texture2D>("WallEdgePillar"));
        textures.Add(General.Content.Load<Texture2D>("WallPillar"));
        textures.Add(General.Content.Load<Texture2D>("FloorEdge"));

        TileSize = new(textures[0].Width, textures[0].Height);
        MapSize = new(TileSize.X * mapTileSize.X, TileSize.Y * mapTileSize.Y);

        Random random = new();

        for (int y = 0; y < mapTileSize.Y; y++) {
            for (int x = 0; x < mapTileSize.X; x++) {
                int r = random.Next(0, 2);
                tiles[x,y] = new(textures[r], new(x * TileSize.X, y * TileSize.Y));
            }
        }

        //setting custom terrain (not randomly generated)
        for (int x = 0; x < mapTileSize.X; x++) {
            tiles[x,19] = new(textures[2], new(x * TileSize.X, 19 * TileSize.Y));
        }
        for (int x = 0; x < mapTileSize.X; x++) {
            tiles[x,18] = new(textures[3], new(x * TileSize.X, 18 * TileSize.Y));
        }
        for (int x = 0; x < mapTileSize.X; x++) {
            tiles[x,17] = new(textures[6], new(x * TileSize.X, 17 * TileSize.Y));
        }
        for (int x = 0; x < mapTileSize.X; x++) {
            for (int i = 0; i < 19; i = i + 3) {tiles[i,19] = new(textures[5], new(i * TileSize.X, 19 * TileSize.Y)); tiles[i,18] = new(textures[4], new(i * TileSize.X, 18 * TileSize.Y));}
        }
    }

    

    public void Draw() {
        for (int y = 0; y < mapTileSize.Y; y++) {
            for (int x = 0; x < mapTileSize.X; x++) {tiles[x,y].Draw();}
        }
    }
}