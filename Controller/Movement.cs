using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody Ch44_nonPBR;
    public Vector2 moveVal;
    public float moveSpeed = 10;

    private void Awake()
    {
        Ch44_nonPBR = GetComponent<Rigidbody>();
    }
    public void Moving(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
          moveVal = value.ReadValue<Vector2>();
          Ch44_nonPBR.AddForce(new Vector3(moveVal.x * moveSpeed, 0f, moveVal.y * moveSpeed), ForceMode.Impulse);
        }
        if (value.canceled)
        {
            moveVal = value.ReadValue<Vector2>();
        }
    }
}
