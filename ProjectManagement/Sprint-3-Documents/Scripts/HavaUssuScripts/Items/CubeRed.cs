using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRed : Collectable
{
    private PlayerInventory playerInventory;
    private void Start()
    {
        playerInventory = GameObject.FindObjectOfType<PlayerInventory>();
    }
    public override void Collect()
    {
        base.Collect();
        if (playerInventory && gameObject.CompareTag("CubeRed"))
        {
            playerInventory.IncreaseCubeRedCount();
            
        }
    }
}
