using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraSetup : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // stores the floats of the coordinates of x, y, z

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset; // first person view without an offset
    }
}