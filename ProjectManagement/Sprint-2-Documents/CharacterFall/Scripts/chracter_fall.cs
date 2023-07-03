using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chracter_fall : MonoBehaviour
{
    Animator anim;
    public float ch_human;

    private void OnCollisionEnter(Collision collision)
    {
         anim.SetBool("dusKalk", true);
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetButton("Vertical"))
        {
            anim.SetBool("dusKalk", false);
        }
    }
}

    
