using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSelectScript : MonoBehaviour
{
    
    public void SelectScene()
    {
        Debug.Log(this.gameObject.name);
        switch (this.gameObject.name)
        {
            case "Level2Button":
            SceneManager.LoadScene (1);
            break;

            case "Level3Button":
            SceneManager.LoadScene (2);
            break;

            case "Level4Button":
            SceneManager.LoadScene (3);
            break;

        }
    }
}
