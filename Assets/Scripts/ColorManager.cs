using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{   // Materials for player, helix and stage-tiles 
    public Material playerMat, normalMat, obstacleMat, helixMat;

    
    public LevelColors[] levelColors;
    [HideInInspector]
    public Color playerColors;

    private void Start()
    {   // Randomly choose the color
        int i = Random.Range(0, levelColors.Length);

        playerColors = levelColors[i].playerColor;
        playerMat.color = playerColors;
        obstacleMat.color = levelColors[i].obstacleColor;
        normalMat.color = levelColors[i].normalColor;
        helixMat.color = levelColors[i].helixColor;

        Camera.main.backgroundColor= levelColors[i].backgroundColor;
    }
    [System.Serializable]
    public class LevelColors
    {
        public Color normalColor;
        public Color obstacleColor;
        public Color playerColor;
        public Color helixColor;
        public Color backgroundColor;
    }
}
