using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    GameController gameController;
    AudioSource aus;
    public AudioClip hitSound;
    public GameObject hitEffect;
    void Start()
    {
        aus = FindObjectOfType<AudioSource>();
        gameController = FindObjectOfType<GameController>();
        GetComponent<Rigidbody2D>().velocity = transform.up * 5;
    }

    int timeCount = 0;

    void Update()
    {
        if (timeCount == 200)
        {
            Destroy(this.gameObject);
            timeCount = 0;
            return;
        }
        timeCount++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameController.ScoreIncrement();
            aus.PlayOneShot(hitSound);
            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
           
        }
        if (collision.CompareTag("EnemyText"))
        {
            gameController.ScoreIncrement();
            aus.PlayOneShot(hitSound);
            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
    
}
