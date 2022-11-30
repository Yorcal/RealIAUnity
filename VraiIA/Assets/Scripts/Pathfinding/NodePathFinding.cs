using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePathFinding
{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public NodePathFinding parent;

    public int gCost; // cost from start to node
    public int hCost; // heuristic cost for target node

    public NodePathFinding(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY){
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost {
        get { return gCost + hCost;}
    }
}
