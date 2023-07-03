using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;

    public float ForwardForce = 200f;
    public float JumpForce = 1000f;
    public float SideForce = 200f;
    public float MovementForce = 500f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Adding forward force in the z-axis
        rb.AddForce(0, 0, ForwardForce * Time.deltaTime);

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, MovementForce * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -MovementForce * Time.deltaTime);
        }

        if ( Input.GetKey("d") )
        {
            rb.AddForce(SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("space"))
        {
            rb.AddForce(0, JumpForce * Time.deltaTime, 0);
        }
    }
}
