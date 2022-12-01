using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCameraControl : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y = this.transform.position.y;
        this.transform.position = playerPosition;
    }
}
