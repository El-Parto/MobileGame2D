using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    
    public Camera camera;
    [SerializeField] private Ball ball;
    [SerializeField] private Bricked brrrr;
    public bool startGame = false;
    public int score = 24;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button restartButt;
    [SerializeField] private Button QuitButt;

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame)
        {
            scoreText.text = score.ToString();
        }

        if(score == 0)
        {
            startGame = false;
            scoreText.text = "Nice!";
            restartButt.gameObject.SetActive(true);
            QuitButt.gameObject.SetActive(true);
        }
            
    }

    public void StartGame() => startGame = true;


    public void RestartGame() => SceneManager.LoadScene("GameScene");

    public void GuitGame()
    {
    #if UNITY_EDITOR
        
    #endif
    }


}
