using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class solarpanel : MonoBehaviour
{
    public Button sunon, sunoff;
    public GameObject panel, keypad;
    public static solarpanel Instance;
    public Material nightsky, daysky;
    public Light directional;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
      keypad.SetActive(false);
      sunon.interactable = false;
      sunoff.interactable = false;
    }

    public void enterstate()
    {
        panel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void cikisbut()
    {
        panel.SetActive(false);
        keypad.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void keypadac()
    {
        panel.SetActive(false);
        keypad.SetActive(true);
    }

    public void keypadkapa()
    {
        panel.SetActive(true);
        keypad.SetActive(false);
    }

    public void donight()
    {
        RenderSettings.skybox = nightsky;
        directional.intensity = 0;
    }

    public void doday()
    {
        RenderSettings.skybox = daysky;
        directional.intensity = 1;
    }
}
