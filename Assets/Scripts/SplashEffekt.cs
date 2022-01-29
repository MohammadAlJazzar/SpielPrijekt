using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffekt : MonoBehaviour
{
    SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.color  = GameManager.Instance.colorManager.playerColors;
        Destroy(gameObject,3);
        
    }
}
