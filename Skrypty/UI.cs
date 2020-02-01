using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreText;
    public Text HighScoreText;
    public GameObject PausePanel;
    public GameObject gameOverPanel;
    public GameObject arrows;
    private GameController gameController;
    private Movement movement;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        movement = FindObjectOfType<Movement>();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        arrows.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
        scoreText.text = gameController.score.ToString();  
        if(gameController.IsDead)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
            arrows.SetActive(false);
        }
    }
    public void PauseButton() 
    {
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            arrows.SetActive(false);
        }
    }
    public void PlayButton() 
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        arrows.SetActive(true);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        gameController.IsDead = false;
        arrows.SetActive(true);
    }
    public void Jump()
    {
        movement.Jump();
    }
    public void Left()
    {
        movement.switchLane(-1);
    }
    public void Right()
    {
        movement.switchLane(1);
    }
}
