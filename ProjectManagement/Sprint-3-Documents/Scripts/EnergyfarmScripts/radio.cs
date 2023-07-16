using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class radio : MonoBehaviour
{
    public float frequency = 100.05f;
    public Text freqtesttext;
    public GameObject radiopanel;
    public Animator anim;

    private void Awake()
    {
        radiopanel.SetActive(false);
    }

    void Update()
    {
        string freqtest = frequency.ToString("0.00");
        freqtesttext.text = freqtest;
      //  Cursor.visible = true;
      //  Cursor.lockState = CursorLockMode.None;
      /*  if (Mathf.Approximately(frequency, 106.20f))
        {
           Debug.Log("radio çalıştı"); 
        }
        */
    }

    public void enterstate()
    {
        radiopanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;   
    }
    
    public void frequplittle()
    {
        frequency += 0.05f;
        if (Mathf.Approximately(frequency, 106.20f))
        {
            anim.SetTrigger("radioplay"); 
        }
    }

    public void freqdownlittle()
    {
        frequency -= 0.05f;
        if (Mathf.Approximately(frequency, 106.20f))
        {
            anim.SetTrigger("radioplay");  
        }
    }

    public void frequp()
    {
        frequency += 1f;
        if (Mathf.Approximately(frequency, 106.20f))
        {
            anim.SetTrigger("radioplay"); 
        }
    }

    public void freqdown()
    {
        frequency -= 1f;
        if (Mathf.Approximately(frequency, 106.20f))
        {
            anim.SetTrigger("radioplay"); 
        }
    }

    public void quit()
    {
        radiopanel.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
