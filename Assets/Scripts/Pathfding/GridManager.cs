using System;
using System.Collections;
using System.Collections.Generic;
using Obvious.Soap;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(GridMap))]
[RequireComponent(typeof(Tilemap))]

public class GridManager : MonoBehaviour
{
    
    public Tilemap _tilemap;
     public GridMapVariable _gridMap;
    public Pathfinding _pathfinding;
    public static GridManager instance;
    public TileSet tileSet;

    public List<Vector3> test;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        BoundsInt bounds = _tilemap.cellBounds;
        _gridMap.size.x = (int) bounds.size.x;
        _gridMap.size.y = (int) bounds.size.y;
        Debug.Log(bounds);
        for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
        {
            for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
            {
                TileBase tile = _tilemap.GetTile(new Vector3Int(x, y, 0));
                if (x >= 0 && y >= 0)
                {
                    if (tile != null)
                    {
                        test.Add(new Vector3(x, y, 0));
                        _gridMap.Set(x, y, false);
                    }
                    else
                    {
                        _gridMap.Set(x, y, true);
                    }
                }
            }
        }

        _pathfinding.Init();
        
    }
}
