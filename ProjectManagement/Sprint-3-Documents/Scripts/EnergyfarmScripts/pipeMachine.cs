using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMachine : MonoBehaviour
{
    public int useable;
    public GameObject targetOpenObj;
    private void OnEnable()
    {
        useable = 1;
    }

    private void OnDisable()
    {
        useable = 0;
    }

    private void Awake()
    {
        targetOpenObj.SetActive(false);
    }

    public void openObject()
    {
        targetOpenObj.SetActive(true);
    }
}
