using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid: MonoBehaviour
{

    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> tiles;

    void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        tiles = new Dictionary<Vector2, Tile>();
        for(int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                int type = Random.Range(0,4);
                if (y%2!=0) {
                    var spawnedTile = Instantiate(tilePrefab, new Vector3((x*0.75f) + 0.375f,(y*0.58f)), Quaternion.identity);

                    spawnedTile.name = "Tile " + x + " " + y;

                    spawnedTile.Init(type);

                    tiles[new Vector2(x,y)] = spawnedTile;
                } else {
                    var spawnedTile = Instantiate(tilePrefab, new Vector3(x*0.75f,(y*0.58f)), Quaternion.identity);
                        
                    spawnedTile.name = "Tile " + x + " " + y;

                    spawnedTile.Init(type);

                    tiles[new Vector2(x,y)] = spawnedTile;
                }
                
            }
        }
        cam.transform.position = new Vector3((float)width/2 - 0.5f, (float)height/2 - 0.5f,-10);
    }

    public Tile GetTileAtPosition(Vector2 pos) {
        if (tiles.TryGetValue(pos, out var tile)) {
            return tile;
        }
        return null;
    }

    public int GetAdjacent(Vector2 pos) {
        if (tiles.TryGetValue(pos, out var tile)) {
            Tile tempTile = tile;
        }
        return 0;
    }
}
