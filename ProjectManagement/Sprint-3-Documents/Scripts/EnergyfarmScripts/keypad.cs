using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class keypad : MonoBehaviour
{
    public static keypad Instance;
   public string Code = "123";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public TextMeshProUGUI UiText = null;
    public int index;
    public GameObject turbine;
    public Animator anim;

    private void Awake()
    {
        Instance = this;
    }

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        if (NrIndex <= 4)
        {
            Nr = Nr + Numbers;
            UiText.text = Nr;  
        }
      //  Nr = Nr + Numbers;
      // UiText.text = Nr;

    }
    public void Enter()
    {
        if (Nr == Code)
        {
          //  Debug.Log("correct");
            if (index == 1)
            {
                Debug.Log("turbine correct");
                anim.SetTrigger("turbine");
            }
            else if (index == 2)
            {
             Debug.Log("solar correct");
             solarpanel.Instance.sunoff.interactable = true;
             solarpanel.Instance.sunon.interactable = true;
            }
            
            
        }
        else
        {
            Debug.Log("false");
        }
    }
    public void Delete()
    {
        NrIndex = 0;
        Nr = null;
        UiText.text = Nr;  
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
