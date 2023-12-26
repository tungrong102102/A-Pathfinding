using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GridMap))]
[RequireComponent(typeof(Tilemap))]

public class GridManager : MonoBehaviour
{
    private Tilemap _tilemap;
    private GridMap _gridMap;

    public TileSet tileSet;
    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _gridMap = GetComponent<GridMap>();
        _gridMap.Init(10,10);
        // _gridMap.Set(1,1,2);
        // _gridMap.Set(1,2,2);
        // _gridMap.Set(2,1,2);
        UpdateTileMap();
    }

    void UpdateTileMap()
    {
        for (int x = 0; x < _gridMap.length; x++)
        {
            for (int y = 0; y < _gridMap.height; y++)
            {
                UpdateTile(x, y);
            }
        }
    }

    private void UpdateTile(int x, int y)
    {
        int tileId = _gridMap.Get(x, y);
        if (tileId == -1)
        {
            return;
        }
        
        _tilemap.SetTile(new Vector3Int(x,y,0),tileSet.tiles[tileId] );
    }

    public void Set(int x, int y,int to)
    {
        _gridMap.Set(x,y,to);
        UpdateTile(x,y);
    }


}
