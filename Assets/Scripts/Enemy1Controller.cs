using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : EnemyController
{
    public float Speed = 5f;
    public BulletEnemyController bulletEnemy;
    public Transform shootPos;
    public AudioSource aus;
    public AudioClip ShootSound;
    int time = 1;
    protected override void Start()
    {
        base.Start();
        aus = FindObjectOfType<AudioSource>();
       
    }

    
   protected override void Update()
    {
        if (time % 200 == 0)
        {
            Shoot();
            time = 0;
        }
        time++;
    }
    void Shoot()
    {
        if (aus && ShootSound)
        {
            aus.PlayOneShot(ShootSound);
        }
        if (shootPos)
            Instantiate(bulletEnemy, shootPos.position, Quaternion.identity);
    }
}
