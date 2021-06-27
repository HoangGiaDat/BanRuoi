using LTAUnityBase.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireInfor
{
    public static bool isFire;
}
public enum StateMove
{
    IDLE,
    LEFT,
    RIGHT
}

public class PlayerController : MonoBehaviour, IPointerDownHandler
{
    public float Speed = 5f;
    public BulletController bullet;
    public Transform shootPos, BtnFire;
    GameController gameController;
    public AudioSource aus;
    public AudioClip ShootSound;
    public ButtonController BtnLeft, BtnRight;
    bool isFire;
    StateMove curentState = StateMove.IDLE;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        BtnLeft.OnClick((ButtonController btn) =>{
            Debug.Log("left");
            curentState = StateMove.LEFT;
        });
        BtnRight.OnClick((ButtonController btn) => {
            Debug.Log("right");
            curentState = StateMove.RIGHT;
        });
       

    }

    // Update is called once per frame
    void Update()
    {
        switch (curentState)
        {
            case StateMove.IDLE:
                transform.position += Vector3.left * 0 * Time.deltaTime;
                break;
            case StateMove.LEFT:
                transform.position += Vector3.left * Speed * Time.deltaTime;
                if (transform.position.x <= -7)
                {
                    curentState = StateMove.IDLE;
                }
                break;
            case StateMove.RIGHT:
                transform.position += Vector3.right * Speed * Time.deltaTime;
                if (transform.position.x >= 7)
                {
                    curentState = StateMove.IDLE;
                }
                break;
        }   
        
        if (FireInfor.isFire == true)
        {
            Shoot();
        }
       
       
    }
    void Shoot()
    {
        if (aus && ShootSound)
        {
            aus.PlayOneShot(ShootSound);
        }
        Instantiate(bullet, shootPos.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameController.SetGameOverState(true);
            Destroy(collision.gameObject);
            Debug.Log("2222");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
