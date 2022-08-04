using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    Rigidbody2D opponentrb;
    Rigidbody2D playerrb;
    bool active;
    public Vector2 force;

    private void Start()
    {
        active = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var opponent = GameObject.FindGameObjectWithTag("Opponent");

        playerrb = player.GetComponent<Rigidbody2D>();
        opponentrb = opponent.GetComponent<Rigidbody2D>();

        if (collision.gameObject.CompareTag("Player") && active)
        {
            playerrb.AddForce(force);
        }
        else if (collision.gameObject.CompareTag("Opponent") && active)
        {
            opponentrb.AddForce(force);
        }
    }
}
