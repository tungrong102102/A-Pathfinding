using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace Pathfding
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Tilemap targetTileMap;
        [SerializeField] private Tilemap higntligntMap;
        public TileBase highTileBase;
        public Pathfinding _pathfinding;
        public Transform target;
        public List<Vector3> test;
        private int currentX = 0;
        private int currentY = 0;
        private int targetX = 0;
        private int targetY = 0;
        private bool isMove;
        public static int block = 0;
        public List<PathNode> path;
        public int currentIndex = 0;
        public float speed;
        private void Start()
        {
            Vector3Int cellPosition = targetTileMap.WorldToCell(transform.position);
            transform.position = targetTileMap.GetCellCenterWorld(cellPosition);
            Debug.Log(block++);

        }


        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentX = (int) transform.position.x;
                currentY = (int) transform.position.y;  
                // targetX = (int) target.position.x;
                // targetY = (int) target.position.y;
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int clickPosition = targetTileMap.WorldToCell(worldPoint);

               
                isMove = true;
            }

            if (isMove)
            {
             
                targetX = (int) target.position.x;
                targetY = (int)  target.position.y;
                path = _pathfinding.FindPath(currentX, currentY, targetX, targetY);
                if (path != null)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        targetTileMap.SetTile(new Vector3Int(path[i].xPos, path[i].yPos, 0), highTileBase);
                    }
                }
                Move();
            }
        }

        public void Move()
        {
            if (path != null)
            {
                PathNode currentNode = path[currentIndex];
                Vector3 positionTarget = new Vector3(currentNode.xPos,currentNode.yPos,0);
                if (Vector3.Distance(positionTarget, transform.position) > 0.1f)
                {
                    Vector3 dir = (positionTarget - transform.position).normalized;
                    transform.position += dir * speed * Time.deltaTime;
                }
                else
                {
                    _pathfinding.SetGrid(currentNode.xPos, currentNode.yPos,0);
                    currentIndex++;
                    if (currentIndex >= path.Count - 1)
                    {

                        transform.position = targetTileMap.WorldToCell(transform.position);
                        isMove = false;
                        
                    }
                }
            }
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
}


//    public void Update()
//    {
       
//            targetTileMap.ClearAllTiles();
//            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            Vector3Int clickPosition = targetTileMap.WorldToCell(worldPoint);
//            transform.position = clickPosition;
//
//            // targetPosX = clickPosition.x;
//            // targetPosY = clickPosition.y;
//            //
        
//            //
            
//        }
    //}

