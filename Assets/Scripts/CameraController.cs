using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smooth = .1f;
    public Transform player;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position; 
    }

    void FixedUpdate()
    {
        if(transform.position.y > player.position.y + offset.y)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + offset, smooth);
        }
        
    }
}
