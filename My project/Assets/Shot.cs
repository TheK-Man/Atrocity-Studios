using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public float speed;
    public GameObject deathEffect;
    
    

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        
    }

    void Update()
    {  

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y){
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            Die();
        }
    }


    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
