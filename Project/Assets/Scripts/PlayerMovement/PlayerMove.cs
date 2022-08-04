using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector2 jumpHeight;
    public float speed;
    Rigidbody2D rb;
    bool canJump;
    Game g;

    void Awake()
    {
        g = FindObjectOfType<Game>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var across = Input.GetAxisRaw("Horizontal") * speed;

        Vector2 movement = new Vector2(across, rb.velocity.y);
        rb.velocity = movement;

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && canJump)
        {
            canJump = false;
            rb.AddForce(jumpHeight);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MakeZone"))
        {
            transform.position = g.playerSpawnLocation;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
