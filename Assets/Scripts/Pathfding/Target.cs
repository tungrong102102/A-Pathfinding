using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Target : MonoBehaviour
{
    [SerializeField] private Tilemap targetTileMap;
    public List<Transform> test;
    
    private void Start()
    {
        Vector3Int cellPosition = targetTileMap.WorldToCell(transform.position);
        transform.position = targetTileMap.GetCellCenterWorld(cellPosition);
    }

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
    }
}
