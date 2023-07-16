using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeYellow : Collectable
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
            playerInventory.IncreaseCubeYellowCount();
        }
    }
}
