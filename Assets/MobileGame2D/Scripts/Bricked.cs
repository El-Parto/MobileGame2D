using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricked : MonoBehaviour
{
    private GuiManager guiM;
    // Start is called before the first frame update
    void Start()
    {
        guiM = FindObjectOfType<GuiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        guiM.score--;
    }
}
