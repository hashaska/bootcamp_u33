using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Craft : PlayerInventory
{
        
    public virtual void crafting() {
        
            if (cubeYellowCount >= 1 && cubeYellowRegularCount >= 2 && barrelYellowCount >= 3 && barrelRedCount >= 2)
            {
                energyBatteryCount = +1;
                cubeYellowCount = 0;
                cubeYellowRegularCount = 0;
                barrelRedCount = 0;
                barrelYellowCount = 0;
            }
    }
}