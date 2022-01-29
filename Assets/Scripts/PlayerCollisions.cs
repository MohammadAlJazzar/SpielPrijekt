using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Class is for SuperMode-, Splasheffect and Collision between the ball and the stage
public class PlayerCollisions : MonoBehaviour
{

    public GameObject splashEffect;
    public ParticleSystem collideEffect;
    

    public GameObject superTrail;
    public int SuperModeAfter = 2;
    int currentSuperMode = 0;
    bool isSuperMode = false;
    

    private void Start()
    {
        SetSuperMode(false);
    }
    // Ball out of the Stage
    private void OnTriggerExit(Collider other)
    {   // Check is a boxcollider in the Stage
        if(other.CompareTag("Check"))
        {
            other.GetComponentInParent<Stage>().Hide();
            GameManager.Instance.levelManager.NextLevel();
            currentSuperMode++;
            Debug.Log(currentSuperMode);
            if(currentSuperMode >= SuperModeAfter)
            {
                SetSuperMode(true);
            }
        }
    }
    // Activate or deactivate SuperModer/Trail Effect 
    void SetSuperMode(bool value)
    {
        isSuperMode = value;
        superTrail.SetActive(isSuperMode);
        if (!isSuperMode){
            currentSuperMode = 0;
        }     
    }

    // Collision between Ball and Stage
    private void OnCollisionEnter(Collision collision)
    {
        // Beginn of splash effect when the player touch the stage
        Vector3 collidePoint = collision.GetContact(0).point;
        GameObject spl = Instantiate(splashEffect, collidePoint + new Vector3(0,.1f,0), splashEffect.transform.rotation);
        spl.transform.SetParent(collision.transform);
        collideEffect.Play();
        
        // check if the player activeted the super mode
        if (isSuperMode)
        {
            // Debug.Log(collision.gameObject.GetComponentInParent<Stage>());
            if (collision.gameObject.GetComponentInParent<Stage>() != null){
                collision.gameObject.GetComponentInParent<Stage>().Hide();
                SetSuperMode(false);
            }
        }

        if (collision.gameObject.CompareTag("Untagged"))
        {      
            SetSuperMode(false);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SetSuperMode(false);
            Die();
        }
    }

    // This method bahabe when the player has no live more in the game
    void Die()
    {   
        GameManager.Instance.uiManager.LiveDecrease(GameManager.Instance.lives-1);
        GameManager.Instance.lives--;
        //GameManager.Instance.levelManager.ReloadScene();

        if (GameManager.Instance.lives == 0)
        {        
            GameManager.Instance.uiManager.Lose();
        } 
    }

}
