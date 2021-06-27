using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameController gameController;
    protected virtual void Start()
    {
        gameController = FindObjectOfType<GameController>();
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
    }

    int timeCount = 0;

   protected virtual void Update()
    {
        if (timeCount == 1000)
        {
            Destroy(this.gameObject);
            timeCount = 0;
            return;
        }
        timeCount++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            //gameController.SetGameOverState(true);
            Destroy(gameObject);
            Debug.Log("3333");
        }
    }
}
