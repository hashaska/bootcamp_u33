using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager1 : MonoBehaviour
{
    [Space(20)] [Header("Objects")] [SerializeField]
    public Button newsbut, newscıkbut, taskac, kapabut;

    public GameObject videoplayer, videopanel, PcPanel, taskpanel;
    private Animator anim;

    private void Awake()
    {
        videopanel.SetActive(false);
        videoplayer.SetActive(false);
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        anim.SetTrigger("wakeup");
        videopanel.SetActive(false);
        videoplayer.SetActive(false);
        PcPanel.SetActive(false);
        taskpanel.SetActive(false);
    }

    public void videoplay()
    {
        videopanel.SetActive(true);
        videoplayer.SetActive(true);
    }

    public void videocik()
    {
        videopanel.SetActive(false);
        videoplayer.SetActive(false);  
    }

    public void taskpanelac()
    {
        taskpanel.SetActive(true);
    }

    public void kapa()
    {
        videopanel.SetActive(false);
        videoplayer.SetActive(false);
        PcPanel.SetActive(false);
        taskpanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
