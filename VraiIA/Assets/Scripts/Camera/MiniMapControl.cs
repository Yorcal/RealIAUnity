using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapControl : MonoBehaviour
{
    public Transform player;
    private Transform followtarget;
    public string followtargetTag;

    void LateUpdate()
    {
        followtarget = GameObject.FindGameObjectWithTag(followtargetTag).transform;
        player = followtarget;
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
