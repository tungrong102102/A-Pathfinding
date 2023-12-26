using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
  [SerializeField] private Tilemap targetTileMap;
  public List<Vector3> test;

  private void Start()
    {
        Vector3Int cellPosition = targetTileMap.WorldToCell(transform.position);
        transform.position = targetTileMap.GetCellCenterWorld(cellPosition);
       
    }
  

  public void Update()
    {
        
    }

    //    public void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            targetTileMap.ClearAllTiles();
//            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            Vector3Int clickPosition = targetTileMap.WorldToCell(worldPoint);
//            transform.position = clickPosition;
//
//            // targetPosX = clickPosition.x;
//            // targetPosY = clickPosition.y;
//            //
//            // List<PathNode> path = _pathfinding.FindPath(currentX,currentY,targetPosX,targetPosY);
//            //
//            // if (path != null)
//            // {
//            //     for (int i = 0; i < path.Count; i++)
//            //     {
//            //         targetTileMap.SetTile(new Vector3Int(path[i].xPos,path[i].yPos ,0),highTileBase);
//            //     }
//            //     currentX = targetPosX;
//            //     currentY = targetPosY;
//            //}
//        }
    //}
    private void OnMouseDown()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = targetTileMap.WorldToCell(worldPoint);
        transform.position = targetTileMap.GetCellCenterWorld(cellPosition);
    }

    private void OnMouseDrag()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = targetTileMap.WorldToCell(worldPoint);
        transform.position = targetTileMap.GetCellCenterWorld(cellPosition);
        foreach (var temp in test)
        {
            if (temp == cellPosition)
            {
                Debug.Log(temp + " " + cellPosition);
            }
        }
    }
}
