using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {

    public float GameSpeed;

	void Start () {
        Time.timeScale = GameSpeed;
	}
	
	void Update () {

	}
}
