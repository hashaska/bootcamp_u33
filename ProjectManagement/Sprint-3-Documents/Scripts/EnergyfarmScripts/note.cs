using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour
{
    [SerializeField] private GameObject notePanel;
    
    void Start()
    {
     notePanel.SetActive(false);
    }

    public void ShowNote()
    {
      notePanel.SetActive(true);
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (notePanel.activeSelf && Input.GetKeyDown(KeyCode.E))
        { 
         notePanel.SetActive(false);
         Cursor.visible = false;
         Cursor.lockState = CursorLockMode.Locked;
        }
    }


}
