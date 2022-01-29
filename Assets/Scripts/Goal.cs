using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class repersent the goal stage (last stage)
public class Goal : MonoBehaviour
{
    //  This method behave when the player touch the goal stage
    private void OnCollisionEnter(Collision collision) 
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.WinGame();
        }
    }
}
