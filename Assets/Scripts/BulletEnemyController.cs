using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    public GameController gameController;
    public AudioSource aus;
    public AudioClip hitSound;
    public GameObject hitEffect;
    protected virtual void Start()
    {
        aus = FindObjectOfType<AudioSource>();
        gameController = FindObjectOfType<GameController>();
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
    }

    public int timeCount = 0;

    protected virtual void Update()
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
        if (collision.CompareTag("Player"))
        {
            gameController.ScoreIncrement();
            aus.PlayOneShot(hitSound);
            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            gameController.SetGameOverState(true);
            Destroy(gameObject);

        }
        if (collision.CompareTag("Bullet"))
        {
            gameController.ScoreIncrement();
            aus.PlayOneShot(hitSound);
            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
