using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class getBehaviourTreeAllParameters : MonoBehaviour
{
    #region Variables
    public float minRandX,maxRandX, minRandZ,maxRandZ;
    public Vector3 target;
    public BehaviorTree bd = null;
    public SharedVector3 targetPosition;
    public PathFinding pathFinding = null;
    #endregion

    private float randX, randZ;
    private SharedBool boolShared;
    private SharedString stringShared;

    //Set the Conflict State
    public void setConflictState(bool state){
        boolShared.Value = state;
        bd.SetVariable("zoneIsInConflict", boolShared);
    }


    //Set the Capture State
    public void setCaptureStateBlue(bool state){
        boolShared = state;
        bd.SetVariable("zoneIsOnCaptureBlue", boolShared);
    }
    public void setCaptureStateRed(bool state){
        boolShared = state;
        bd.SetVariable("zoneIsOnCaptureRed", boolShared);
    }

    //Set Captured State
    public void setCapturedStateBlue(bool state){
        boolShared = state;
        bd.SetVariable("zoneCapturedBlue", boolShared);
    }
    public void setCapturedStateRed(bool state){
        boolShared = state;
        bd.SetVariable("zoneCapturedRed", boolShared);
    }
    //Set the Random Position for the Target
    public void RandomPosition(float randX, float randZ){
        randX = Random.Range(minRandX, maxRandX);
        randZ = Random.Range(minRandZ, maxRandZ);
        target = new Vector3(randX, 0, randZ);
        targetPosition.Value = target;
        bd.SetVariable("posToTarget", targetPosition);
    }

    public void setStringTag(string tag){
        stringShared = tag;
        bd.SetVariable("tagToTarget", stringShared);
    }

    public void assignTagtoScript(string tag){
        GameObject.Find("A*").GetComponent<PathFinding>().targetTag = tag;
        GameObject.Find("A*").GetComponent<PathFinding>().tankFind = false;
    }



}
