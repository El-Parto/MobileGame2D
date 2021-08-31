using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Vector3 beforeTouchPos;
    public Vector3 releaseTouchpos;
    public Vector3 currentPos;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movePlatform()
    {
        RaycastHit2D hitObject;
        
        
        if(Input.GetMouseButton(0))
        {
            
        }
    }
}
