using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text score;
    GameSession session;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
        session = FindObjectOfType<GameSession>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = session.GetScore().ToString();
	}
}
