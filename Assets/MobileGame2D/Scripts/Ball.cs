using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //controls the position of the ball at the start of the game.
#region StartPosition

    //private float yOffset = .65f;
    private Vector3 staticBallPos;
    [SerializeField] private GameObject startPaddle;
    private bool startGame = false;

#endregion

    [SerializeField] private Rigidbody2D ballRB;
    private float initBallSpeed = 600;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        ballRB.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startGame)
        {
            staticBallPos = startPaddle.transform.position;
            gameObject.transform.position = new Vector3(staticBallPos.x, staticBallPos.y);
            ballRB.velocity= Vector2.zero;
            
        }
        else
            ballRB.isKinematic = false;
        
            

    }

    private void OnTriggerEnter2D(Collider2D _trigger)
    {
        if(_trigger.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }
    }

    public void ActivateBall()
    {
        startGame = true;
        ballRB.isKinematic = true;
        if(!startGame)
            ballRB.AddForce(Vector2.up * initBallSpeed);
    }
}
