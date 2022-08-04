using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeasonBoard : MonoBehaviour
{
    public Text TheText;

    private void Start()
    {
        Mule.Get(C.M_KEY_SEASONTEXT, TheText.text);
        
        var games = Mule.Get(C.M_KEY_GAME, 0);

        string opponent = "Nobody";

        switch (games)
        {
            case 0: opponent = "DookieHousers"; break;
            case 1: opponent = "Panthers"; break;
            case 2: opponent = "Hornets"; break;
            case 3: opponent = "Erasers"; break;
            case 4: opponent = "Rough Riders"; break;
            case 5: opponent = "The Eagles"; break;
            case 6: opponent = "Golden State"; break;
            case 7: opponent = "SuperStars"; break;
            case 8: opponent = "World Champions"; break;
        }


        //i did this because i thought it was cool
        var newLine = "\n";

        Mule.Set(C.M_KEY_OPPONENT, opponent);


        Mule.Set(TheText.text, C.M_KEY_SEASONTEXT);

        TheText.text = C.M_KEY_SEASONTEXT;

        TheText.text += newLine + " vs " + opponent;

        Mule.Set(C.M_KEY_SEASONTEXT, TheText.text);
    }
}
