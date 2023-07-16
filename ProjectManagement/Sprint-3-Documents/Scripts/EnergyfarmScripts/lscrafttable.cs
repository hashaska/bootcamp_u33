using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class lscrafttable : MonoBehaviour
{
    [SerializeField] private int redpot;
    [SerializeField] private int greenpot;
    [SerializeField] private int bluepot;
    [SerializeField] private int scrap;
    [SerializeField] private TextMeshPro recipetext;
    public GameObject craftposobj;
    public GameObject craftedobj;
    void Start()
    {
        redpot = 0;
        greenpot = 0;
        bluepot = 0;
        scrap = 0;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (recipetext.text != string.Empty)
        {
            recipetext.text += "\n" + col.gameObject.tag;
        }
        else
        {
            recipetext.text = col.gameObject.tag;
        }
        if (col.gameObject.CompareTag("redpot"))
        {
            redpot++;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("greenpot"))
        {
            greenpot++;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("bluepot"))
        {
            bluepot++;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("scrap"))
        {
            scrap++;
            Destroy(col.gameObject);
        }
        
        
    }

    void Update()
    {
        
        if (redpot ==1 && greenpot == 1 && bluepot == 1 && scrap == 3)
        {
            Instantiate(craftedobj, craftposobj.transform.position, quaternion.identity);
            redpot = 0;
            greenpot = 0;
            bluepot = 0;
            scrap = 0;
            recipetext.text = String.Empty;
        }  
    }
}
