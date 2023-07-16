using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    public GameObject spotlight;
    public bool flashon;
    void Start()
    {
      spotlight.SetActive(false);
      flashon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
          spotlight.SetActive(true);  
        } 
    }
}
