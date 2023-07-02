using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itempickable : MonoBehaviour,Ipickable
{
    public itemSo itemScriptableObject;

    public void PickItem()
    {
        Destroy(gameObject);
    }
}

