using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Camera camera;
    public Vector3 beforeTouchPos;
    public Vector3 releaseTouchpos;
    public Vector3 currentPos;
    private GuiManager gui;
    
    [SerializeField] private LayerMask playerMsk;

    [SerializeField] private GameObject selectedplayer; //
    [SerializeField] private bool beingDragged = false; // bool to set whether or not the player is being dragged

    [SerializeField]private float leftScreenPos;// determines the value of the left side of the screen to clamp
    [SerializeField]private float rightScreenPos; // determines the value of the right side of the screen to clamp'

    [SerializeField]private float mousePos;
    // Start is called before the first frame update
    void Start()
    {
        playerMsk = LayerMask.GetMask("PlayerMsk");
        gui = FindObjectOfType<GuiManager>();
        camera = FindObjectOfType<Camera>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 _currentPos = CurrentMousePos();
        //mousePos = Screen.height;
        if(beingDragged)
        {
            //Vector3 _currentPos = CurrentMousePos();
            selectedplayer.transform.position = _currentPos;
        }
        
        ScreenClamping();

        SelectPlatformMouse();
        beingDragged = true;
        
        
        
        //because I'm using the world space of the camera screen, no matter how you scale it, it's always between -10 and 10.
        // Using ths value, i don't have to worry about doing calculations on how big the screen should be scaled for mouse/touch
        // position.
        _currentPos.x = Mathf.Clamp(_currentPos.x, -9, 9);
        
        //selectedplayer.transform.position = new Vector3(_currentPos.x, camera.rect.height );
    }

    private void ScreenClamping()
    {/*
        leftScreenPos = camera.pixelWidth - camera.pixelWidth * 0.1f;
        rightScreenPos = (camera.pixelWidth / camera.pixelWidth) camera.pixelWidth;
        mousePos = Mathf.Clamp(Input.mousePosition.x, leftScreenPos, rightScreenPos);

    */}

    /// <summary>
    /// Controls the platform via raycasting based on what you touch/click.
    /// </summary>
    public void SelectPlatformMouse()
    {
    #if UNITY_ANDROID
        if(Input.GetMouseButtonDown(0))
        {
            // allows a raycast to be drawn from wherever our mouse is, for android builds, this would mostlikely be ignored.
            Ray raycastDrawer = Camera.main.ScreenPointToRay(Input.mousePosition);
            //#if UNITY_ANDROID

            //#endif
            // allows ray cast to collect info based on the parameters in this case, it's drawing from the origin of our raycast
            // in the direction of the where the mouse is and only selects whatever is in the layermask playermask,
            RaycastHit2D theHitObject = Physics2D.Raycast(raycastDrawer.origin, raycastDrawer.direction, Mathf.Infinity, playerMsk);
            if(theHitObject != null)
            {
                selectedplayer = theHitObject.collider.gameObject;
                beingDragged = true;
            }
        }

        if(beingDragged) // gets game object to be dragged around
        {
            Vector3 _currentPos = CurrentMousePos();
            selectedplayer.transform.position = _currentPos;
        }
        //if(Input.GetMouseButtonUp(0))// upon release, stop drag
        //  beingDragged = false;


    }
#endif
    private Vector3 CurrentMousePos() => currentPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 30, 10));

}
        

    




