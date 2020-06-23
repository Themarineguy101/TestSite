using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight = 35f;

    void Update()
    {
        if (player != null) { 
            Vector3 pos = player.transform.position;
        pos.y += cameraHeight;
        transform.position = pos; }
    }
}
