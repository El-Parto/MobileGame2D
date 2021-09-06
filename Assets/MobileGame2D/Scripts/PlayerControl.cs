using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Vector3 beforeTouchPos;
    public Vector3 releaseTouchpos;
    public Vector3 currentPos;
    private GuiManager gui;
    
    [SerializeField] private LayerMask playerMsk;

    [SerializeField] private GameObject selectedplayer;
    [SerializeField] private bool beingDragged = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMsk = LayerMask.GetMask("PlayerMsk");
        
    }

    // Update is called once per frame
    void Update()
    {

        SelectPlatformMouse();
        
    }

    
    /// <summary>
    /// Controls the platform via raycasting based on what you touch/click.
    /// </summary>
    public void SelectPlatformMouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // allows a raycast to be drawn from wherever our mouse is, for android builds, this would mostlikely be ignored.
            Ray raycastDrawer = Camera.main.ScreenPointToRay(Input.mousePosition);
            //#if UNITY_ANDROID

            //#endif
            // allows ray cast to collect info based on the parameters in this case, it's drawing from the origin of our raycast
            // in the direction of the where the mouse is and only selects whatever is in the layermask playermask,
            RaycastHit2D theHitObject = Physics2D.Raycast(raycastDrawer.origin, raycastDrawer.direction, Mathf.Infinity, playerMsk);
            if(theHitObject!= null)
            {
                selectedplayer = theHitObject.collider.gameObject;
                beingDragged = true;
            }
            
            
                
            

        }
        
        
        
        if(beingDragged)
        {
            Vector3 _currentPos = CurrentMousePos();
            selectedplayer.transform.position = _currentPos;
        }
        if(Input.GetMouseButtonUp(0))
            beingDragged = false;

        // The position of the selected  object is declared here.


    }

    private Vector3 CurrentMousePos() => currentPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 10, 10));
    
    public void MovePlatformMouse()
    {

    }
}
