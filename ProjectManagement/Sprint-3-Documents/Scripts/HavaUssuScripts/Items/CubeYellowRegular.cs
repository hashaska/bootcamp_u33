using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeYellowRegular : Collectable
{
    private PlayerInventory playerInventory;
    private void Start()
    {
        playerInventory = GameObject.FindObjectOfType<PlayerInventory>();
    }
    public override void Collect()
    {
        base.Collect();
        if (playerInventory)
        {
            playerInventory.IncreaseCubeYellowRegularCount();
        }
    }
}
