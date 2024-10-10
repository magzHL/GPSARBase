using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GPSLocationSpawn : MonoBehaviour
{

    [SerializeField]

    public GameObject ARObject;

    bool createdARO = false;

    public TMP_Text debugTxt;
    
   

    // Update is called once per frame
    void Update()
    {
        debugTxt.text = "";
        spawnObject();
    }

    private void spawnObject()
    {
        
        if (createdARO == false)
        {
            createdARO = true;
            Instantiate(ARObject, new Vector3(), Quaternion.identity);
        }
        
        
    }

}

