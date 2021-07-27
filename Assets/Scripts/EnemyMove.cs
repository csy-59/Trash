using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    float currentSpeed;
    public int damage;
    public float damageCool;
    public float findDistance;
    PlayerMove player;

    SpriteRenderer sp;

    void Start()
    {
        rigid = GameObject.FindObjectOfType<Rigidbody2D>();
        player = GameObject.FindObjectOfType<PlayerMove>();
        sp = GameObject.FindObjectOfType<SpriteRenderer>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionedObject = collision.gameObject;

        //tag ���� �ʿ�!
        if (collisionedObject.CompareTag("EndPoint"))
        {
            currentSpeed *= -1;
            sp.flipX = (speed < 0);
        }
        else if (collisionedObject.CompareTag("Player"))
        {
            currentSpeed = 0;
            Attack();
        }
        else if(collisionedObject.CompareTag("Attack"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Move", 1);
        }
    }

    void Attack()
    {
        player.Attacked(damage,transform.position);
    }

    void Move()
    {
        currentSpeed = speed;
    }
}
