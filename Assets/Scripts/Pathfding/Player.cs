using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private Tilemap targetTileMap;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetTileMap.ClearAllTiles();
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickPosition = targetTileMap.WorldToCell(worldPoint);
            transform.position = clickPosition;

            // targetPosX = clickPosition.x;
            // targetPosY = clickPosition.y;
            //
            // List<PathNode> path = _pathfinding.FindPath(currentX,currentY,targetPosX,targetPosY);
            //
            // if (path != null)
            // {
            //     for (int i = 0; i < path.Count; i++)
            //     {
            //         targetTileMap.SetTile(new Vector3Int(path[i].xPos,path[i].yPos ,0),highTileBase);
            //     }
            //     currentX = targetPosX;
            //     currentY = targetPosY;
            //}
        }
    }
}
