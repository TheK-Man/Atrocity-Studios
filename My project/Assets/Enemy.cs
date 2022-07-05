using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Stats")]
    public float walkSpeed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    public float shootSpeed;
    private float timeBtwShots;
    public Transform firePoint2;
    private Vector2 direction;
    
    

    [Header ("References")]
    
    private Transform player;
    
    

    public int health = 100;

    public GameObject deathEffect;
    public GameObject bullet;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update ()
    {
        
    
        //Makes the enemy move
        if(Vector2.Distance(transform.position, player.position) > nearDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance){
            transform.position = this.transform.position;
        }

        if(player.position.x > transform.position.x && transform.localScale.x > 0 
         || player.position.x < transform.position.x && transform.localScale.x < 0)
        {
         Flip();
        }

        
        
       
       
        
        
    
        //Makes the enemy shoot
        if(timeBtwShots <= 0){
        GameObject newBullet = Instantiate(bullet, firePoint2.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * -walkSpeed * Time.fixedDeltaTime, 0f);
            timeBtwShots = startTimeBtwShots;
        } else {
            timeBtwShots -= Time.deltaTime;
            
        }

       
       
       

    }

    void Flip()
    {
       transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
       
       walkSpeed *= 1;
       if(Vector2.Distance(transform.position, player.position) > nearDistance){
    transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed * Time.deltaTime);
} else if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
    transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed * Time.deltaTime);
} else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance){
    transform.position = this.transform.position;
}
       
    } 

    
    
    
    



    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }






















}
