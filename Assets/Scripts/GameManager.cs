using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// main Class It has several classes inside
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public ColorManager colorManager;

    public LevelManager levelManager;

    public UIManager uiManager;

    public bool isGameOn = false;

    public ScoreManager scoreManager;
    
    public int lives;

    private void Awake()
    {
        Instance = this;
        lives=3;
    }

    public void StartGame()
    {
        isGameOn = true; 
    }
   
    public void LoseGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.lose);
        isGameOn = false;
    }

    public void WinGame()
    {
        if (LevelManager.getScene() < 4  )
        {
            levelManager.LoadNextScene();
            Debug.Log("Naechste Nivau");
        }else
        {
            isGameOn = false;
            uiManager.Win();
            levelManager.WinLevel();
        }
        
    }


}
