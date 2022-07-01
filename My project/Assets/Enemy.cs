using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float timeBtwShots;

    [Header ("References")]
    public GameObject shot;
    private Transform player;

    public int health = 100;

    public GameObject deathEffect;

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
    }

    void Update ()
    {
        //Makes the enemy move
        if(Vector2.Distance(transform.position, player.position) < nearDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance){
            transform.position = this.transform.position;
        }
        
        //Makes the enemy shoot
        if(timeBtwShots <= 0){
            Instantiate(shot, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else {
            timeBtwShots -= Time.deltaTime;
        }

    }

    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }






















}
