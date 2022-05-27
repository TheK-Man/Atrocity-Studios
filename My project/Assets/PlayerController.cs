using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public float moveSpeed;
 private Rigidbody2D rb;
 private bool facingRight = true;
 private float moveDirection;
 Vector2 movement;

private void Awake() 
 {

     rb = GetComponent<Rigidbody2D>();
 }

 void Update() 
 {
 movement.x = Input.GetAxisRaw("Horizontal");
 movement.y = Input.GetAxisRaw("Vertical");
 moveDirection = Input.GetAxis("Horizontal");
 

 if (moveDirection > 0 && !facingRight)
{
    FlipCharacter();
}
else if (moveDirection < 0 && facingRight)
{
    FlipCharacter();
}

 }

     private void FlipCharacter()
{
    facingRight = !facingRight; //Inverse bool
    transform.Rotate(0f, 180f, 0f);
}


 private void FixedUpdate() 
 {
 movement.Normalize();
 rb.velocity = new Vector2(movement.x * moveSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime);

 }
 

 

}
 
 
 

