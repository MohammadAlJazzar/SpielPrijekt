using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;
    public Rigidbody rb;

    public float jumpForce = 9;

    bool canJump = true;

    private void OnCollisionEnter(Collision collision)
    {
        Jump();
    }
    void Jump()
    {
        // play sound in Jumping
        SoundManager.Instance.PlaySound(SoundManager.Instance.jump);
        int i = Random.Range(0, 3);
        // play Animator-trigger Jump1,Jump2 or Jump3
        anim.SetTrigger("Jump" + i);
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // jump
            canJump = false;
            Invoke("ResetCanJump", .1f); // Calling the function after a certain time
        }
    }
    void ResetCanJump()
    {
        canJump = true;
    }


}
