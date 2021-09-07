using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    
    //public Camera camera;
    [SerializeField] private Ball ball;
    public bool startGame = false; // activated by pressing the "Activate ball" button
    public int score = 24;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI controlText;
    
    [SerializeField] private Button restartButt;
    [SerializeField] private Button QuitButt;

    public bool wonGame = false;

    public bool loseGame = false;
    // Start is called before the first frame update
    void Start()
    {
        //camera = FindObjectOfType<Camera>();
        
    }

    // Update is called once per frame
    public void Update()
    {
        WinLoseRestartGame();
    }

   // public void StartGame() => startGame = true;


    public void RestartGame() => SceneManager.LoadScene("GameScene");

    public void GuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
        #else
            Application.Quit(); 
        #endif
    }

    private void WinLoseRestartGame()
    {
        if(startGame)
        {
            scoreText.text = score.ToString();
            controlText.gameObject.SetActive(false);

        }

        if(loseGame)
        {
            restartButt.gameObject.SetActive(true);
            QuitButt.gameObject.SetActive(true);
            scoreText.text = "(- _-'')";
            scoreText.color = new Color(0.35f, 0.0f, 0.0f, 0.35f);
        }

        if(score == 0)
        {
            startGame = false;
            wonGame = true;
            scoreText.text = "Nice!";
            scoreText.color = new Color(0, 0.8f, 0.0f, 0.85f);
            restartButt.gameObject.SetActive(true);
            QuitButt.gameObject.SetActive(true);
            
        }
            
        if(wonGame)
        {
            ball.ballRB.velocity = Vector2.zero;
        }
    }

}
