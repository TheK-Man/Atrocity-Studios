using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        //Get Inputs
       moveDirection = Input.GetAxis("Horizontal");
       
       //Animate
if (moveDirection > 0 && !facingRight)
{
    FlipCharacter();
}
else if (moveDirection < 0 && facingRight)
{
    FlipCharacter();
}

       
       //Move
       rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
       
    }
   
    private void FlipCharacter()
{
    facingRight = !facingRight; //Inverse bool
    transform.Rotate(0f, 180f, 0f);
}

}
