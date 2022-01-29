using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;

// This class is responsible for the user interfaces
public class UIManager : MonoBehaviour
{
    public GameObject startPanel, winPanel, losePanel;

    [Header("Text")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timerText;

    public Texture empty;
    public Texture full;

    public GameObject[] hearts;

    float roundTimer;
    bool gameOver = false;

    public void Start()
    {   // Calculation of time for each level
        int level = LevelManager.getScene() +1 ;                   // Level1=2, level2=3, level3=4
        int decrease = (level - 2) * 4 ;                           // (2-2)*4
        int countStage = level * 16 ;         
        roundTimer = countStage - decrease ; 
    }

    public void Update()
    {
        
        if (!gameOver)
        {
            livesText.text = GameManager.Instance.lives.ToString();
            roundTimer = roundTimer - Time.deltaTime;
            timerText.text= ((int)roundTimer).ToString();
        }    
        if (roundTimer <= 0f && gameOver== false )
        {
            roundTimer=-30f;
            gameOver=true;
            Debug.Log("Zeit abgelaufen");
            Lose();

        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        GameManager.Instance.StartGame();

    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f; 
        GameManager.Instance.levelManager.LoadStartScene();  

    }

    public void Lose()
    {
        losePanel.SetActive(true);
        GameManager.Instance.LoseGame();
        Time.timeScale = 0.0f;   

       
    }

    public void Win()
    {
        winPanel.SetActive(true);
    }
    private void OnEnable()
    {
        ScoreManager.UpdatedScore += ScoreManager_UpdatedScore;
    }
    void ScoreManager_UpdatedScore(int obj)
    {
        scoreText.text = obj.ToString();
    }

    public void LiveDecrease(int number)
    {
        hearts[number].SetActive(false);
    }

    public void LiveIncrease(int number)
    {
        hearts[number].SetActive(true);
    }

}
