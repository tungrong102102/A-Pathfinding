using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridControl : MonoBehaviour
{
    [SerializeField] private Tilemap targetTileMap;
    [SerializeField] private GridManager _gridManager;

    private Pathfinding _pathfinding;
    
    private GameObject player;
    
    
    private int currentX = 0;
    private int currentY = 0;
    private int targetPosX = 0;
    private int targetPosY = 0;

    [SerializeField] private TileBase highTileBase;
    
    private void Update()
    {
        MouseInput();
        _pathfinding = _gridManager.GetComponent<Pathfinding>();
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetTileMap.ClearAllTiles();
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickPosition = targetTileMap.WorldToCell(worldPoint);

            targetPosX = clickPosition.x;
            targetPosY = clickPosition.y;

            List<PathNode> path = _pathfinding.FindPath(currentX,currentY,targetPosX,targetPosY);

            if (path != null)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    targetTileMap.SetTile(new Vector3Int(path[i].xPos,path[i].yPos ,0),highTileBase);
                }
                currentX = targetPosX;
                currentY = targetPosY;
            }
        }
    }

    private void A(Vector2 Start, Vector2 End)
    {
        
    }
}
