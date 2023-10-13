using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderHole : MonoBehaviour {

	// Use this for initialization

    GameObject Hero;
	void Start () {
        Hero = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("HIT!");
        Hero.SendMessage("resetPosition");
    }

}
