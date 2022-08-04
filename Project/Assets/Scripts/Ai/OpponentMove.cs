using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMove : MonoBehaviour
{

    Rigidbody2D rb;
    public Transform balltrans;
    bool jump;
    public Vector2 jumpHeight;
    float timetiljump;
    float timer = 0;
    public float speed;
    private bool canJump;
    private bool canMove;
    Game g;

    void Awake()
    {
        g = FindObjectOfType<Game>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var ball = FindObjectOfType<BallMovement>();

        transform.rotation = Quaternion.Euler(0, 180, 0);

        var y = transform.position.y;

        //if (rb.velocity.x < .1f || rb.velocity.x > -.1f && canMove && transform.position.y > ball.transform.position.y)
        //{
        //    Vector2 force = new Vector2(Random.Range(-250,250), 1);
        //    rb.AddForce(force);
        //}

        if (timer == 0)
        {
            timetiljump = Random.Range(7, 10);
        }

        timer += Time.deltaTime;

        if (timer >= timetiljump)
        {
            jump = true;
            timer = 0;
        }

        if (jump && canJump)
        {
            jump = false;
            canJump = false;
            timer = 0;
            timetiljump = Random.Range(7, 10);
            rb.AddForce(jumpHeight);
        }

        //var dir = Vector3.MoveTowards(transform.position, balltrans.position + new Vector3(.4f, 0, 0), speed);
        //transform.position = dir;
        //transform.position = new Vector3(transform.position.x, y);

        transform.position += (ball.transform.position - transform.position).normalized * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y);

        //transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, ball.transform.position.x, speed), transform.position.y);

        //if (transform.position.x < ball.transform.position.x)
        //{
        //    var dir = Vector3.MoveTowards(transform.position, balltrans.position + new Vector3(0f, 0, 0), speed);
        //    transform.position = new Vector3(dir.x, y);
        //    //transform.position = new Vector3(transform.position.x, y);
        //}
        //else if (transform.position.x > ball.transform.position.x && transform.position.x - ball.transform.position.x > 1)
        //{
        //    var dir = Vector3.MoveTowards(transform.position, balltrans.position, speed);
        //    transform.position = dir;
        //    transform.position = new Vector3(transform.position.x, y);
        //}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MakeZone"))
        {
            transform.position = g.opponentSpawnLocation;
        }
    }
}
