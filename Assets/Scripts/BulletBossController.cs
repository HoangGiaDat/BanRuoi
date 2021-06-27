using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossController : BulletEnemyController
{
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (transform.localScale.x >= 2)
            return;
        ScaleBullet();
    }
    void ScaleBullet()
    {
        transform.localScale += Vector3.one * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //gameController.ScoreIncrement();
            aus.PlayOneShot(hitSound);
            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            gameController.SetGameOverState(true);
            Destroy(gameObject);

        }
        if (collision.CompareTag("Bullet"))
        {
            //gameController.ScoreIncrement();
            aus.PlayOneShot(hitSound);
            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
