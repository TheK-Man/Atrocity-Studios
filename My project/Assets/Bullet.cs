using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dieTime, damage, speed;
    public GameObject deathEffect;
    


    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(CountDownTimer());
         
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);

        Die();
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


