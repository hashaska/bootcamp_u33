using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tape : MonoBehaviour
{
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private AudioClip soundClip;
   public static tape Instance;
   public int tapenum = 0;

   private void Awake()
   {
      Instance = this;
      audioSource = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
     //audioSource = GetComponent<AudioSource>();
   }

   public void TapePlay()
   {
       if (!audioSource.isPlaying)
       {
           audioSource.PlayOneShot(soundClip);   
       }
   }
 /* public IEnumerator TapeSound()
   {
       yield return new WaitForSeconds(1f);
       if (!audioSource.isPlaying)
       {
        audioSource.PlayOneShot(soundClip);   
       }
   }
*/

}
