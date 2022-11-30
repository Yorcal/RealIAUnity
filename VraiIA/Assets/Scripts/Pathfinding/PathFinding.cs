using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public Transform seeker, target;
    GridPathFinding grid;

    void Update()
    {
        FindPath(seeker.position, target.position);
    }

    void Awake()
    {
        grid = GetComponent<GridPathFinding>();
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        NodePathFinding startNode = grid.NodeFromWorldPoint(startPos);
        NodePathFinding targetNode = grid.NodeFromWorldPoint(targetPos);

        List<NodePathFinding> openSet = new List<NodePathFinding>();
        HashSet<NodePathFinding> closedSet = new HashSet<NodePathFinding>();
        openSet.Add(startNode);

        while (openSet.Count > 0) {
            NodePathFinding currentNode = openSet[0];
            for (int i=1; i<openSet.Count; i++) {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == targetNode){
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (NodePathFinding neighbour in grid.GetNeighbours(currentNode)){
                if(!neighbour.walkable || closedSet.Contains(neighbour)){
                    continue;
                }

                int newCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                if( newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if(!openSet.Contains(neighbour)){
                        openSet.Add(neighbour);
                    }
                }
            }
        }
    }

    void RetracePath(NodePathFinding startNode, NodePathFinding endNode) {
        List<NodePathFinding> path = new List<NodePathFinding>();
        NodePathFinding currentNode = endNode;

        while(currentNode != startNode) {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }

    int GetDistance(NodePathFinding nodeA, NodePathFinding nodeB) {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if(distX > distY) {
            return 14*distY + 10 * (distX-distY);
        }
        return 14*distX + 10 * (distY-distX);
    }
}
