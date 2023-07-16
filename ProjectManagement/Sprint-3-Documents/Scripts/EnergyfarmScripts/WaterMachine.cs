using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMachine : MonoBehaviour
{
    public static WaterMachine Instance;
    public GameObject pipe1, pipe2, gen1, gen2;
    public int pipenum, gennum;
    private void Awake()
    {
        Instance = this;
        pipe1.SetActive(false);
        pipe2.SetActive(false);
        gen1.SetActive(false);
        gen2.SetActive(false);
        pipenum = 0;
    }

    public void OpenPipe1()
    {
        if (pipenum == 0)
        {
            pipe1.SetActive(true);
            pipenum = 1;  
        }
       else if (pipenum == 1)
        {
          pipe2.SetActive(true);  
        }
    }

    public void Opengen()
    {
        if (gennum == 0)
        {
            gen1.SetActive(true);
            gennum = 1;
        }
        else if (gennum == 1)
        {
            gen2.SetActive(true);  
        }  
    }
    
   
    
}
