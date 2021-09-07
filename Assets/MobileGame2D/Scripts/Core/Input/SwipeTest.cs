using NullFrameworkException.Mobile.InputHandling;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// include namespace

public class SwipeTest : MonoBehaviour
{
    private LineRenderer lRend;
    [SerializeField] private Camera camera;
                                         
    // Start is called before the first frame update
    void Start()
    {
        lRend = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MobileInputManager.Instance.swiping.SwipeCount > 0)
        {
            SwipeInputHandler.Swipe swipe = MobileInputManager.Instance.swiping.GetSwipe(0);
            lRend.positionCount = swipe.positions.Count;
            //lRend.transform.position = new Vector3 (swipe.positions[i].x,swipe.positions[i].y, camera.nearClipPlane)
            for(int i = 0; i < lRend.positionCount; i++)
            {
                lRend.SetPosition(i,camera.ScreenToWorldPoint(swipe.positions[i]));
                // for 3D??
                //lRend.SetPosition(i,camera.ScreenToWorldPoint(new Vector3 (swipe.positions[i].x,swipe.positions[i].y, camera.nearClipPlane)));
            }
        }
        else
        {
            lRend.positionCount = 0;
        }
    }
}
