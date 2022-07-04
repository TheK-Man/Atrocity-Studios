using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dieTime, damage;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(CountDownTimer());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      Die();
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);

        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}    


