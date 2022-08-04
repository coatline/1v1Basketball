using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpponentText : MonoBehaviour
{
    Text opponent;

    private void Start()
    {
        opponent = GetComponent<Text>();
        
        opponent.text = Mule.Get(C.M_KEY_OPPONENT, "New Jersey");
        //GamesPlayed = Mule.Get(C.M_KEY_GAME, 0);
    }

}
