using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class RandomPositionTarget : MonoBehaviour
{
    public float minRandX,maxRandX, minRandZ,maxRandZ;
    public Vector3 target;
    public BehaviorTree bd = null;
    public SharedVector3 targetPosition;

    private float randX, randZ;

    public void RandomPosition(float randX, float randZ){
        randX = Random.Range(minRandX, maxRandX);
        randZ = Random.Range(minRandZ, maxRandZ);
        target = new Vector3(randX, 0, randZ);
        targetPosition.Value = target;
        bd.SetVariable("posToTarget", targetPosition);
    }
}
