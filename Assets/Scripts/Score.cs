using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text score;
    GameSession game;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
        game = FindObjectOfType<GameSession>();
    }
	
	// Update is called once per frame
	void Update () {
        score.text = game.GetScore().ToString();
	}
}
