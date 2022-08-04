using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public GameObject spaceStart;
    public Text text;
    public Text opponent;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            Destroy(spaceStart);
            Destroy(text);   
        }
    }
}
