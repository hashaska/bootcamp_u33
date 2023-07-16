using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    public GameObject agac;
    public GameObject player;
    public float mesafe;
    public float distance;
    public float fallSpeed = 50f;
    private bool hasFallen = false;
    private Rigidbody rigidBodyAgac;
    private void Start()
    {
        GameObject foundObject = GameObject.FindGameObjectWithTag("Agac");
        rigidBodyAgac = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, agac.transform.position);
        if (!hasFallen && distance < mesafe)
        {
            Fall();
        }
        if (distance<19f)
        {
            rigidBodyAgac.isKinematic = true;
        }
    }

    void Fall()
    {
        // Yerçekimi etkisini kapat / aç
        rigidBodyAgac.useGravity = true;

        // Aðacý yere doðru döndür
        rigidBodyAgac.AddTorque(Vector3.left * fallSpeed, ForceMode.Impulse);
        
        // Agac yerde ise dogrula
        hasFallen = true;       
        
    }
}
