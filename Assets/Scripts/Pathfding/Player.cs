using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MEC;
using Obvious.Soap;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace Pathfding
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Tilemap targetTileMap;
        private int currentX = 0;
        private int currentY = 0;
        private int targetX = 0;
        private int targetY = 0;
        private bool isMove;
        public List<PathNode> pathNodes;
        public float _speed;
        public Player target;
        public GridMapVariable _gridMap;
        public List<Transform> posTarget;
        public List<bool> isFull;

        private void Start()
        {
            Vector3Int cellPosition = targetTileMap.WorldToCell(transform.position);
            transform.position = targetTileMap.GetCellCenterWorld(cellPosition);
            Timing.RunCoroutine(Move());
        }

        public IEnumerator<float> Move()
        {

            int currentPathIndex = 0;
            Vector3 temp = target.FindClosestTransform(transform).transform.position;
            Vector3Int targetPosition =
                new Vector3Int((int) temp.x, (int) temp.y);
            pathNodes = GridManager.instance._pathfinding.FindPath((int) transform.position.x,
                (int) transform.position.y,
                targetPosition.x, targetPosition.y);
            while (currentPathIndex < pathNodes.Count)
            {
                temp = target.FindClosestTransform(transform).transform.position;
                Vector3Int newTargetPosition =
                    new Vector3Int((int) temp.x, (int) temp.y);

                if (newTargetPosition != targetPosition)
                {
                    targetPosition = newTargetPosition;
                    // Recalculate path when the target moves
                    currentPathIndex = 0;
                    pathNodes = GridManager.instance._pathfinding.FindPath((int) transform.position.x,
                        (int) transform.position.y,
                        targetPosition.x, targetPosition.y);
                    Timing.RunCoroutine(Move().CancelWith(gameObject));
                }

                var currentNode = pathNodes[currentPathIndex];
                var nextPosition = new Vector3(currentNode.xPos, currentNode.yPos, 0);

                if (!_gridMap.Value[currentNode.xPos, currentNode.yPos])
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextPosition, _speed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, nextPosition) < 0.1f)
                    {
                        if (currentPathIndex > 0)
                        {
                            _gridMap.Value[pathNodes[currentPathIndex - 1].xPos, pathNodes[currentPathIndex - 1].yPos] =
                                false;
                        }

                        _gridMap.Value[currentNode.xPos, currentNode.yPos] = true;
                        currentPathIndex++;

                        if (currentPathIndex < pathNodes.Count && _gridMap.Value[pathNodes[currentPathIndex].xPos,
                                pathNodes[currentPathIndex].yPos])
                        {
                            currentPathIndex = 0;
                            temp = target.FindClosestTransform(transform).transform.position;
                            targetPosition = new Vector3Int((int) temp.x, (int) temp.y);
                            pathNodes = GridManager.instance._pathfinding.FindPath((int) transform.position.x,
                                (int) transform.position.y,
                                targetPosition.x, targetPosition.y);
                        }
                    }
                }

                yield return Timing.WaitForOneFrame;
            }

        }
        Transform FindClosestTransform(Transform pos)
        {
            float minDistance = float.MaxValue;
            Transform closestTransform = null;
            List<Transform> temp = target.posTarget;
            for (int i = 0; i < temp.Count; i++)
            {
            }

            return closestTransform;
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

