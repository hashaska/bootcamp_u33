using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class morse : MonoBehaviour
{
    public Button but1, but2, but3, but4;
    public GameObject morse1, morse2, morse3, morse4, keypad, morsepanel, turbine;

    private void Awake()
    {
        keypad.SetActive(false);
        turbine.SetActive(false);
        morsepanel.SetActive(false);
    }

    public void turbinestate()
    {
      turbine.SetActive(true);
      morsepanel.SetActive(true);
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
    }
    
    public void button1()
    {
      morse1.GetComponent<Animator>().SetTrigger("morse1");  
    }
    
    public void button2()
    {
        morse2.GetComponent<Animator>().SetTrigger("morse2"); 
    }
    
    public void button3()
    {
        morse3.GetComponent<Animator>().SetTrigger("morse3");  
    }
    
    public void button4()
    {
        morse4.GetComponent<Animator>().SetTrigger("morse4"); 
    }

    public void keypadac()
    {
        keypad.SetActive(true);
        morsepanel.SetActive(false);
    }

    public void keypadkapa()
    {
        keypad.SetActive(false);
        morsepanel.SetActive(true);
    }

    public void cikis()
    {
       morsepanel.SetActive(false);
       Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
    }
    
}
