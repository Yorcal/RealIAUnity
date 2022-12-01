using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GridPathFinding grid;
    public Vector3 nextPosistion = Vector3.zero;
    public float speed = 5f;
    public float turnSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        grid = null;
        nextPosistion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("A*").GetComponent<GridPathFinding>() != null && grid == null){
            grid = GameObject.Find("A*").GetComponent<GridPathFinding>();
        }
        else {
            if(grid.path.Count>0){
                nextPosistion = grid.GetSeekerNextPosition();
            }
            
            if (nextPosistion != transform.position){
                transform.position = Vector3.MoveTowards(transform.position, nextPosistion, speed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nextPosistion - transform.position), turnSpeed * Time.deltaTime);
            }
        }
    }
}
