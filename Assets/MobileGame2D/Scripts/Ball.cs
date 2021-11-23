using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private GuiManager guiManager;
    //controls the position of the ball at the start of the game.
#region StartPosition

    //private float yOffset = .65f;
    private Vector3 staticBallPos;
    [SerializeField] private GameObject startPaddle;
    private bool startGame = false;
    public Button startGameButton;

    [SerializeField] private AudioSource sfxToPlay;
    [SerializeField] private AudioSource[] sfxTotoChoose;
    [SerializeField] private AudioMixerGroup sfxSound;

#endregion

    public Rigidbody2D ballRB;
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
        if(!guiManager.startGame)
        {
            staticBallPos = startPaddle.transform.position;
            gameObject.transform.position = new Vector3(staticBallPos.x, staticBallPos.y);
            ballRB.velocity= Vector2.zero;
            
        }
        // else
            //ballRB.isKinematic = false;



    }

    private void OnTriggerEnter2D(Collider2D _trigger)
    {
        //destroy upon triggering the collider
        if(_trigger.CompareTag("DeathZone"))
        {
            sfxSound.audioMixer.SetFloat("SFX_Pitch", 1);
            sfxToPlay = sfxTotoChoose[1];
            sfxToPlay.Play();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Activates the ball so that it may move around freely via 2D physics.
    /// </summary>
    public void ActivateBall()
    {
        guiManager.startGame = true;
        //ballRB.isKinematic = false;
        ballRB.AddForce(new Vector2(100, initBallSpeed));
        startGameButton.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Destroy the collider's gameobject passed through, which is the brick.
        if(other.collider.CompareTag("Folder"))
        {
            float randPitch = UnityEngine.Random.Range(0.3f, 2.2f);
            sfxSound.audioMixer.SetFloat("SFX_Pitch", randPitch);
            sfxToPlay = sfxTotoChoose[0];
            sfxToPlay.Play();
            Destroy(other.gameObject);
        }

        // play the specified sound upon contact with GO tagged "Wall"
        if(other.collider.CompareTag("Wall"))
        {
            float randPitch = UnityEngine.Random.Range(0.3f, 2.2f);
            sfxSound.audioMixer.SetFloat("SFX_Pitch", randPitch);
            sfxToPlay = sfxTotoChoose[0];
            sfxToPlay.Play();
        }

        // play the specified sound upon contact with the player GO
        if(other.collider.CompareTag("Player"))
        {
            float randPitch = UnityEngine.Random.Range(0.3f, 2.2f);
            sfxSound.audioMixer.SetFloat("SFX_Pitch", randPitch);
            sfxToPlay = sfxTotoChoose[0];
            sfxToPlay.Play();
        }
        
    }

    private void OnDestroy() => guiManager.loseGame = true; // if the game object is destroyed, set the bool to lose game and activate lose screen.

}
