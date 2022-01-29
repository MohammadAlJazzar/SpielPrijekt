using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represent the Stage object on the game 
public class Stage : MonoBehaviour
{
    public Animator anim;
    
    // Tag name to define the obstacle tile  
    public string ObstacleTag = "Obstacle";

    // This component used to give color to each tile on the stage
    public MeshRenderer[] meshRenderers;
    
    // Array of tiles on the stage. Each tile is obstacle, normal, or thru
    public Tile[] tiles;

    // This Method behave hide of stage if the player go through from one stage to another 
    public void Hide() 
    {
        anim.SetTrigger("Hide");
        GameManager.Instance.levelManager.NextLevel();
        GameManager.Instance.scoreManager.AddScore(2);
    }

    // distribute the tiles of stage on the type of tile (obstacle, normal, or thru)
    private void Start()
    {
        for(int i=0; i < 12; i++)
        {
            switch(tiles[i].tiletype)
            {
                case TileType.Obstacle:
                    meshRenderers[i].tag = ObstacleTag;
                    meshRenderers[i].material = GameManager.Instance.colorManager.obstacleMat;
                    break;
                case TileType.Thru:
                    meshRenderers[i].gameObject.SetActive(false);
                    break;
            }
        }
        
    }
}


[System.Serializable]
public class Tile
{
    public TileType tiletype;
}

// This Enum is all type of tile 
public enum TileType  
{
    Normal, Obstacle, Thru
}
