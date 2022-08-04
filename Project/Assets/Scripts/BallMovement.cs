using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D rb;
    GameClock gc;
    public int points = 2;
    public string player;
    public Vector3 pt;
    bool final;
    public bool menu;

    void Awake()
    {
        if (menu) return;
        gc = FindObjectOfType<GameClock>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (menu) return;
        pt = new Vector3(0, 0, 0);
        float x = Random.Range(-.1f, .1f);
        float y = Random.Range(-.5f, .5f);
        Vector2 Fly = new Vector2(x, y);
        rb.AddForce(Fly);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (menu) return;
        if (collision.gameObject.CompareTag("Backboard"))
        {
            rb.velocity = new Vector2(rb.velocity.x / 4, rb.velocity.y);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            gc.canStop = true;
        }

        if (collision.gameObject.CompareTag("Opponent"))
        {
            gc.canStop = true;
            player = "Opponent";
            pt = collision.gameObject.transform.position;
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            gc.canStop = true;
            player = "Player";
            pt = collision.gameObject.transform.position;
        }

        else if (collision.gameObject.transform.parent != null)
        {
            if (collision.gameObject.transform.parent.CompareTag("Opponent"))
            {
                gc.canStop = true;
                player = "Opponent";
                pt = collision.gameObject.transform.position;
            }
            else if (collision.gameObject.transform.parent.CompareTag("Player"))
            {
                gc.canStop = true;
                player = "Player";
                pt = collision.gameObject.transform.position;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (menu) return;
        if (collision.gameObject.CompareTag("MakeZone"))
        {
            if (player == "Player" && pt.x > 0 && !final)
            {
                points = 3;
            }
            else if (player == "Opponent" && pt.x < 0 && !final)
            {
                points = 3;
            }
            //so it can stop if it is zero seconds left
            gc.canStop = true;
            gc.canStop = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (menu) return;
        if (collision.gameObject.CompareTag("Ground"))
        {
            points = 2;
            final = true;
            gc.canStop = false;
        }
        if (collision.gameObject.CompareTag("Opponent"))
        {
            gc.canStop = false;
            final = false;
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            gc.canStop = false;
            final = false;
        }

        else if (collision.gameObject.transform.parent != null)
        {
            if (collision.gameObject.transform.parent.CompareTag("Opponent"))
            {
                gc.canStop = false;
                final = false;
            }
            else if (collision.gameObject.transform.parent.CompareTag("Player"))
            {
                gc.canStop = false;
                final = false;
            }
        }

    }
}
