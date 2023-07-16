using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] public float cubeRedCount = 0;
    [SerializeField] public float cubeYellowCount = 0;
    [SerializeField] public float barrelYellowCount = 0;
    [SerializeField] public float barrelRedCount = 0;
    [SerializeField] public float energyBatteryCount = 0;
    [SerializeField] public float cubeYellowRegularCount = 0;


    private void Start()
    {
        
    }

    public void IncreaseCubeRedCount()
    {
        cubeRedCount++;
    }
    public void IncreaseCubeYellowCount()
    {
        cubeYellowCount++;
    }
    public void IncreaseEnergyBatteryCount()
    {
        energyBatteryCount++;
    }
    public void IncreaseBarrelRedCount()
    {
        barrelRedCount++;
    }
    public void IncreaseBarrelYellowCount()
    {
        barrelYellowCount++;
    }
    public void IncreaseCubeYellowRegularCount()
    {
        cubeYellowRegularCount++;
    }

}
