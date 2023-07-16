using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject agac;
    public float mesafe;
    public float distance;
    public float fallSpeed = 10f;
    private Rigidbody rigidBodyAgac;
    private void Start()
    {
        GameObject foundObject = GameObject.FindGameObjectWithTag("Agac");
        rigidBodyAgac = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        distance = Vector3.Distance(this.transform.position, agac.transform.position);
        if (distance<mesafe)
        {
            Fall();
        }
    }

    void Fall()
    {
        // Yer�ekimi etkisini kapat
        rigidBodyAgac.useGravity = false;

        // A�ac� yere do�ru d�nd�r
        rigidBodyAgac.AddTorque(Vector3.left * fallSpeed, ForceMode.Impulse);
    }
}
