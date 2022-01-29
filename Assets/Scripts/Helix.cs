using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represent the helix object on the game and behave the routate. 
public class Helix : MonoBehaviour
{
    // init the speed of rotate of helix
    public float speed = 25;

    Vector2 lastMousePos;

    private void Update()   // move Hilex after click and drag
    {
        // check if the game is running 
        if(!GameManager.Instance.isGameOn)
        {
            return;
        }
        // check if the user has pressed the left mouse button on the helix
        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = Input.mousePosition;
            if(lastMousePos == Vector2.zero)
            {
                lastMousePos = currentMousePos;
            }
            Vector2 delta = currentMousePos - lastMousePos;
            transform.Rotate(new Vector3(0, 1, 0), -delta.x * speed * Time.deltaTime);
            lastMousePos = currentMousePos;
        }
        // check if the left mouse button is up than restart the prosition of the mouse pointer to zero
        if (Input.GetMouseButtonUp(0))  
        {
            lastMousePos = Vector3.zero;
        }
    }
}
