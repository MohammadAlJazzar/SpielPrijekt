using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public GameObject startLevel; // the first Stage
    public GameObject goalPrefab; // the last Stage
    public GameObject[] levels;  // Array of Stages
    
    public float trasitionTime= 1f;
    public Animator transition;

    public int maxOnScreen = 10;  // in the same time max 10 Stages
    public int firstSpawn = 5;    
    public float distance = 5;   // Distance between 2 Stages
    public Transform Helix;     
    Vector3 spawnPos;

    List<GameObject> levelsSpawnd = new List<GameObject>();
    int levelsSpawndCount = 0;

    // slider
    public int levelStages = 0;
    int stageOn = 0;
    
    [Header("Slider")]
    public TextMeshProUGUI currentText;
    public TextMeshProUGUI nextText;
    public Slider levelSlider;

    private void Awake()
    {
        // The number of stages per Scene
        levelStages = 8* (getScene()+1);
        SetSliderValues();
    }
    void SetSliderValues()
    {
        levelSlider.maxValue = levelStages;
        levelSlider.value = 0;
        nextText.text = levelStages.ToString();
    }

    private void Start()
    {
        for (int i=0; i< firstSpawn; i++)
        {
            SpawnLevel();
        }

     }
    // ADD Stage to the Game
    void SpawnLevel()
    {
        GameObject newLevel;
        // first Stage
        if (levelsSpawndCount == 0)
        {
            newLevel = Instantiate(startLevel, spawnPos, Quaternion.identity);
        }
        
        else if (levelsSpawndCount < levelStages)
        {
            newLevel = Instantiate(levels[Random.Range(0, levels.Length)], spawnPos, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        }
        // Goal-stage after last Stage
        else if (levelsSpawndCount == levelStages)
        {
            newLevel = Instantiate(goalPrefab, spawnPos,Quaternion.identity);
        }
        else
        {
            return;
        }
        
        newLevel.transform.SetParent(Helix, true);
        spawnPos.y -= distance;

        levelsSpawnd.Add(newLevel);
        levelsSpawndCount++;

        if(levelsSpawndCount > maxOnScreen)
        {
            Destroy(levelsSpawnd[0]);
            levelsSpawnd.RemoveAt(0);
        }

    }

    public void NextLevel()
    {
        SpawnLevel();
        AddPoint();
    }
    // Show score on slider 
    void AddPoint()
    {
        stageOn++;
        levelSlider.value = stageOn;
        currentText.text = stageOn.ToString();
    }

    public void WinLevel()
    {
        Debug.Log("Du hast gewonnen");
    }

    public void LoadNextScene()
    {
        StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Von Anfang an");
    }
    // repeat the same Scene "not in Use"
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reload Scene");
    }
    // Get number of the Scene
    public static int getScene()
    {
       return SceneManager.GetActiveScene().buildIndex;
    }

    IEnumerator Loadlevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(trasitionTime);
        SceneManager.LoadScene(levelIndex);
    }


}

