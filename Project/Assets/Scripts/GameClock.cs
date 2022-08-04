using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameClock : MonoBehaviour
{
    public Text timer;
    public float timeLeft;
    public int game;
    public bool canStop;
    //public event Action TimeToChangeText;

    private void Start()
    {
        
    }

    void Update()
    {
        game = Mule.Get(C.M_KEY_GAME, 0);
        
            if (timeLeft <= 0f && canStop)
            {
                if (game < 8)
                {
                    Mule.Set(C.M_KEY_GAME, 0);
                    SceneManager.LoadScene(1);
                }
                else
                {
                    Mule.Set(C.M_KEY_GAME, 0);
                    SceneManager.LoadScene(3);
                }
            }
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        timer.text = timeLeft.ToString("00.");
    }
}
