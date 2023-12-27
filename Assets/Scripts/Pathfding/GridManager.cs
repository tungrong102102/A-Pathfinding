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
    private Pathfinding _pathfinding;

    public TileSet tileSet;

    public List<Vector3> test;
    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _gridMap = GetComponent<GridMap>();
        _pathfinding = GetComponent<Pathfinding>();
        BoundsInt bounds = _tilemap.cellBounds;
        _gridMap.Init(bounds.size.x,bounds.size.y);
        for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
        {
            for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
            {
                TileBase tile = _tilemap.GetTile(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    test.Add(new Vector3(x,y,0));
                    _gridMap.Set(x,y,0);
                }
                else
                {
                    _gridMap.Set(x, y, 2);
                }
            }
        }
        _pathfinding.gridMap = _gridMap;
        _pathfinding.Init(); 
        
//        _gridMap.Init(10,10);
        // _gridMap.Set(13,5,2);
        // _gridMap.Set(13,6,2);
        // _gridMap.Set(13,4,2);
        // UpdateTileMap();
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

    // public void Set(int x, int y,int to)
    // {
    //     _gridMap.Set(x,y,to);
    //     UpdateTile(x,y);
    // }
}
