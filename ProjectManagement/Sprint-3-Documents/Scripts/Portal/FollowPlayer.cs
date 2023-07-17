using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // stores the floats of the coordinates of x, y, z
    public float rotationSpeed = 5f;

    private bool isRotating = false;

    // Update is called once per frame
    void LateUpdate()
    {
        // Calculate distance and relative angle
        Vector3 cameraToPlayer = player.position - transform.position;
        float distanceToPlayer = cameraToPlayer.magnitude;
        float angleToPlayer = Mathf.Atan2(cameraToPlayer.x, cameraToPlayer.z) * Mathf.Rad2Deg;

        // Check for right mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }

        // Rotate the camera if right mouse button is held down
        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            Quaternion rotation = Quaternion.Euler(0f, mouseX, 0f);
            offset = rotation * offset;
        }

        // Stop rotating when right mouse button is released
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        // Set camera position and rotation based on player
        Vector3 desiredPosition = player.position + offset;
        transform.position = desiredPosition;
        transform.LookAt(player.position);

        // Print distance and relative angle to the console
        Debug.Log("Distance to player: " + distanceToPlayer);
        Debug.Log("Angle to player: " + angleToPlayer);
    }
}