using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public Text scoreText;

    float time;

    private float score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time = Time.deltaTime;
        score += time * 100;

        scoreText.text = "" + (int)score;
	}
    public void damage()
    {
        score -= 500;
        Debug.Log("a");
    }
}
