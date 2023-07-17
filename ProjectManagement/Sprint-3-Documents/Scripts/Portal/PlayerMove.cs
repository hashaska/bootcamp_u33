using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraTransform; // Reference to the camera's transform

    public float ForwardForce = 200f;
    public float JumpForce = 1000f;
    public float SideForce = 200f;
    public float MovementForce = 500f;

    // Update is called once per frame
    void Update()
    {
        // Get the camera's forward and right vectors based on its rotation
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0f; // Make the vectors horizontal (no vertical movement)

        // Normalize the vectors to ensure consistent force application
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction based on camera axis
        Vector3 movementDirection = Vector3.zero;
        if (Input.GetKey("w"))
        {
            movementDirection += cameraForward;
        }

        if (Input.GetKey("s"))
        {
            movementDirection -= cameraForward;
        }

        if (Input.GetKey("d"))
        {
            movementDirection += cameraRight;
        }

        if (Input.GetKey("a"))
        {
            movementDirection -= cameraRight;
        }

        // Apply the movement force in the calculated direction
        rb.AddForce(movementDirection * MovementForce * Time.deltaTime);

        if (Input.GetKey("space"))
        {
            rb.AddForce(0, JumpForce * Time.deltaTime, 0);
        }

        if (Input.GetKey("b"))
        {
            rb.AddForce(0, -JumpForce * Time.deltaTime, 0);
        }
    }

    // Teleport the player to the spawn position
    public void TeleportToSpawnPoint(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;

        // Reset the player's velocity
        rb.velocity = Vector3.zero;
    }
}