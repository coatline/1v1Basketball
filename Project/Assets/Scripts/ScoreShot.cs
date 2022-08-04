using System;
using UnityEngine;


public class ScoreShot : MonoBehaviour
{
    public event Action ShotMade;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (ShotMade != null) ShotMade();
        }
    }
}
