using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private GuiManager guiManager;
    //controls the position of the ball at the start of the game.
#region StartPosition

    //private float yOffset = .65f;
    private Vector3 staticBallPos;
    [SerializeField] private GameObject startPaddle;
    private bool startGame = false;
    public Button startGameButton;

#endregion

    [SerializeField] private Rigidbody2D ballRB;
    private float initBallSpeed = 600;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        guiManager = FindObjectOfType<GuiManager>();
        //ballRB.isKinematic = true;
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
        // else
            //ballRB.isKinematic = false;

            if(guiManager.wonGame)
            {
                ballRB.velocity = Vector2.zero;
            }

    }

    private void OnTriggerEnter2D(Collider2D _trigger)
    {
        if(_trigger.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Activates the ball so that it may move around freely via 2D physics.
    /// </summary>
    public void ActivateBall()
    {
        startGame = true;
        //ballRB.isKinematic = false;
        ballRB.AddForce(new Vector2(100, initBallSpeed));
        startGameButton.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Folder"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy() => guiManager.loseGame = true;

}
